using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamLeader : MonoBehaviour
{
    public Transform target;
    public float walkingSpeed = 3f;
    public float followDistance = 2f;

    private Animator animator;
    private Vector3 lastTargetPosition;
    private Vector2 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lastTargetPosition = target.position;
    }

    private void Update()
    {
        Vector3 targetPosition = target.position;

        if (Vector3.Distance(transform.position, targetPosition) > followDistance)
        {
            // Calculate movement direction
            movement = targetPosition - transform.position;
            movement.Normalize();

            // Move the leader towards the target
            transform.position += (Vector3)movement * walkingSpeed * Time.deltaTime;


            // Update animator parameters
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.magnitude);

            // Update last target position
            lastTargetPosition = targetPosition;
        }
        else
        {
            // Stop moving and reset animator parameters
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0f);
        }

        // Check if target position has changed
        if (lastTargetPosition != targetPosition)
        {
            // Update animator parameters for facing direction
            Vector2 facingDirection = targetPosition - transform.position;
            facingDirection.Normalize();
            //animator.SetFloat("FacingX", facingDirection.x);
            //animator.SetFloat("FacingY", facingDirection.y);
        }
    }
}
