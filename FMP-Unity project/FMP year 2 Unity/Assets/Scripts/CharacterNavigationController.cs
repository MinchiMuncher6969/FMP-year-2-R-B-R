using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class CharacterNavigationController : MonoBehaviour
{
    public float movementSpeed = 1;
    public float roatationSpeed = 120;
    public float stopDistance = 2f;
    public Vector3 destination;
    public Animator animator;
    public bool reachedDestination;

    private Vector3 lastPosition;
    Vector3 velocity;

    private void Awake()
    {
        movementSpeed = Random.Range(0.5f, 2f);
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDestance = destinationDirection.magnitude;
            if(destinationDestance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, roatationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            }
            else
            {
                reachedDestination = true;
            }
            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);

            animator.SetFloat("Horizontal", rightDotProduct);
            animator.SetFloat("Forward", fwdDotProduct);
        }
        lastPosition = transform.position;
    }
    public void SetDestination(Vector3 destination)
    {
      this.destination = destination;
         reachedDestination = false;
    }
}
