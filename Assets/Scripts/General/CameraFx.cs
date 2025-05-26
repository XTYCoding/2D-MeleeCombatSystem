using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFx : MonoBehaviour
{
    private static CameraFx _instance;
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

    private bool isShake;
    public void HitPause(int duration)
    {
        StartCoroutine(Pause(duration));
    }

    IEnumerator Pause(int duration)
    {
        float pauseTime = duration / 60; //duration是帧数，计算暂停时间
        Time.timeScale = 0;              //游戏暂停
        yield return new WaitForSeconds(pauseTime); //等一段时间后恢复正常游戏速度
        Time.timeScale = 1;
    }

    public void CameraShake(float duration,float power)
    {
        if (!isShake) //避免频繁震动
        {
            StartCoroutine(Shake(duration,power));
        }
    }

    IEnumerator Shake(float duration,float power )
    {
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPosition = camera.position;

        while (duration>0)
        {
            camera.position = Random.insideUnitSphere*power + startPosition;
            duration -= Time.timeScale;
            yield return null;
        }
        camera.position = startPosition; //震动完镜头恢复原始位置
        isShake = false;
    }
}
