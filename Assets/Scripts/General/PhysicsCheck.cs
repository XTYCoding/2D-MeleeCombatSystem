using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 物理检测组件，用于检测地面、墙体、玩家等
public class PhysicsCheck : MonoBehaviour
{
    [SerializeField]private Entity entity; // 关联的实体对象
    public bool isGrounded; // 是否在地面上
    public bool wallDetected; // 是否检测到墙体
    public Transform groundDetect; // 地面检测点
    public Transform wallDetect; // 墙体检测点
    public Transform playerDetect; // 玩家检测点
    public float groundDetectDist; // 地面检测距离
    public float wallDetectDist; // 墙体检测距离
    public float playerDetectDist; // 玩家检测距离
    public float playerContactedDist; // 玩家接触检测距离
    public LayerMask groundLayer; // 地面层
    public LayerMask wallLayer; // 墙体层
    public LayerMask playerLayer; // 玩家层

    // 是否检测到玩家（左右两个方向射线检测）
    public bool playerDetected
        => playerDetect != null && Physics2D.Raycast(
            playerDetect.position,
            entity.facingDir * Vector2.right,
            playerDetectDist,
            playerLayer)||Physics2D.Raycast(
            playerDetect.position,
            entity.facingDir * Vector2.left,
            playerDetectDist,
            playerLayer);

    // 是否与玩家接触（只检测面朝方向）
    public bool playerContacted
        => playerDetect != null && Physics2D.Raycast(
            playerDetect.position,
            entity.facingDir * Vector2.right,
            playerContactedDist,
            playerLayer);

    // MonoBehaviour生命周期：Awake，在对象激活时调用
    void Awake()
    {
        //entity = GetComponent<Entity>();
    }

    // MonoBehaviour生命周期：Update，每帧调用一次
    private void Update()
    {
        CheckGround(); // 检查地面
        WallDetected(); // 检查墙体
    }

    // 检查是否在地面上
    private void CheckGround()
    {
        if (groundDetect == null) return;

        isGrounded = Physics2D.Raycast(groundDetect.position, Vector2.down, groundDetectDist, groundLayer);
    }

    // 检查是否检测到墙体
    private void WallDetected()
    {
        if (wallDetect == null) return;
        wallDetected = Physics2D.Raycast(wallDetect.position, entity.facingDir*Vector2.right, wallDetectDist, wallLayer);
    }

    // 在Scene视图中绘制检测射线辅助线
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundDetect.position, groundDetect.position + Vector3.down * groundDetectDist);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallDetect.position, wallDetect.position + entity.facingDir * Vector3.right * wallDetectDist);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerDetect.position, playerDetect.position + entity.facingDir * Vector3.right * playerDetectDist);
        Gizmos.DrawLine(playerDetect.position, playerDetect.position + entity.facingDir * Vector3.left * playerDetectDist);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerDetect.position, playerDetect.position + entity.facingDir * Vector3.right * playerContactedDist);
    }
}