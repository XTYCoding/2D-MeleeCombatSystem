using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundDetect;
    public float groundDetectDist;
    public LayerMask groundLayer;

    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        if (groundDetect == null) return;

        // ʹ�� Raycast ������
        isGrounded = Physics2D.Raycast(groundDetect.position, Vector2.down, groundDetectDist, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(groundDetect.position, groundDetect.position + Vector3.down * groundDetectDist);
    }
}


