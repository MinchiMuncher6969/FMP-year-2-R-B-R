using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterControler : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public Transform cam;

    public float speed = 100.0f;
    public float gravity = 1.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpSpeed = 8.0F;
    public float Running = 150.0f;
    public float NormalSpeed = 100.0f;


    // Update is called once per frame
    void Update()
    {
        
        //controller.Move(Physics.gravity * gravity * Time.deltaTime);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDir.normalized * speed * Time.deltaTime);

        }
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl))
        {
            speed = Running;
        }
        else
        {
            speed = NormalSpeed;
        }

    }
}
