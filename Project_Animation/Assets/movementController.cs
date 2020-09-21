using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    float speed = 4;
    float rotation_speed = 80;
    float rotation = 0;
    float gravity = 8;

    Vector3 move_direction = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                move_direction = new Vector3(0, 0, 1);
                move_direction *= speed;
                move_direction = transform.TransformDirection(move_direction);
            }
            if(!Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
                move_direction = new Vector3(0, 0, 0);
            }

            rotation += Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rotation, 0);

            move_direction.y -= gravity * Time.deltaTime;
            controller.Move(move_direction * Time.deltaTime);
        }
    }
}
