using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFx : MonoBehaviour
{
    private static CameraFx _instance;

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineImpulseSource impulseSource;
    private Vector3 originalOffset;

    private bool isShake;
    public static CameraFx Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Transform.FindAnyObjectByType<CameraFx>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (virtualCamera == null)
            virtualCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
        if (virtualCamera == null)
        {
            Debug.LogError("CameraFx: 没有找到 CinemachineVirtualCamera！");
            return;
        }

        var transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (transposer == null)
        {
            Debug.LogError("CameraFx: CinemachineVirtualCamera 没有 CinemachineTransposer 组件！");
            return;
        }
    

    }

    public void HitPause(int duration)
    {
        StartCoroutine(Pause(duration));
    }

    IEnumerator Pause(int duration)
    {
        float pauseTime = (float)duration / 60; //duration是帧数，计算暂停时间
        Time.timeScale = 0;              //游戏暂停
        yield return new WaitForSecondsRealtime(pauseTime); //等一段时间后恢复正常游戏速度
        Time.timeScale = 1;
    }

    public void CameraShake(float duration,float power)
    {
        if (isShake) return;
        if (impulseSource != null)
        {
            isShake = true;
            impulseSource.GenerateImpulse(power);
            StartCoroutine(ShakeCooldown(duration));
        }
    }

    private IEnumerator ShakeCooldown(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        isShake = false;
    }

    IEnumerator Shake(float duration, float power)
    {
        isShake = true;
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        Vector3 originalPos = transposer.m_TrackedObjectOffset;
        float timer = 0f;
        while (timer < duration)
        {
            transposer.m_TrackedObjectOffset = originalPos + (Vector3)Random.insideUnitCircle * power;
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        transposer.m_TrackedObjectOffset = originalPos;
        isShake = false;
        // isShake = true;
        // Transform camera = Camera.main.transform;
        // Vector3 startPosition = camera.position;

        // while (duration>0)
        // {
        //     camera.position = Random.insideUnitSphere*power + startPosition;
        //     duration -= Time.timeScale;
        //     yield return null;
        // }
        // camera.position = startPosition; //震动完镜头恢复原始位置
        // isShake = false;
    }
}
