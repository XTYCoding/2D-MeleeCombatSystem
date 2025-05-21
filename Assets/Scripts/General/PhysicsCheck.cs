using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [SerializeField]private Entity entity;
    public bool isGrounded;
    public bool wallDetected;
    public Transform groundDetect;
    public Transform wallDetect;
    public Transform playerDetect;
    public float groundDetectDist;
    public float wallDetectDist;
    public float playerDetectDist;
    public float playerContactedDist;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public LayerMask playerLayer;


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

    public bool playerContacted
        => playerDetect != null && Physics2D.Raycast(
            playerDetect.position,
            entity.facingDir * Vector2.right,
            playerContactedDist,
            playerLayer);

    void Awake()
    {
        //entity = GetComponent<Entity>();
    }

    private void Update()
    {
        CheckGround();
        WallDetected();
    }

    private void CheckGround()
    {
        if (groundDetect == null) return;

        isGrounded = Physics2D.Raycast(groundDetect.position, Vector2.down, groundDetectDist, groundLayer);
    }

    private void WallDetected()
    {
        if (wallDetect == null) return;
        wallDetected = Physics2D.Raycast(wallDetect.position, entity.facingDir*Vector2.right, wallDetectDist, wallLayer);
    }


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


