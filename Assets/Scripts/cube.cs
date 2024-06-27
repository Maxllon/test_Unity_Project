using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Vector
{
    FRONT = 0,
    RIGHT,
    LEFT,
    BACK
}

public class main_cube : MonoBehaviour
{
    [SerializeField] private float rotate_speed;
    [SerializeField] private float move_speed;
    private Vector vec;
    private bool is_move;
    private Vector3 size;
    private Vector3 rotation_center;
    private Vector3 rotation_start_center;
    private Vector3 rotation_direction;

    private void Start()
    {
        is_move = false;
        size = transform.localScale;
    }
    private void Update()
    {
        if(is_move)
        {
            if(Vector3.Distance(transform.position, rotation_start_center) >= size.x) is_move = false;
            else
            {
                transform.RotateAround(rotation_center, rotation_direction, rotate_speed * Time.deltaTime);
            }
        }
        else if(Input.anyKey)
        {
            is_move = true;
            rotation_start_center = transform.position;
            if(Input.GetKey(KeyCode.W))
            {
                rotation_center = transform.position + new Vector3(size.x/2, -size.y/2, 0);
                rotation_direction = Vector3.back;
                return;
            }
            if(Input.GetKey(KeyCode.S))
            {
                rotation_center = transform.position + new Vector3(-size.x/2, -size.y/2, 0);
                rotation_direction = Vector3.forward;
                return;
            }
            if(Input.GetKey(KeyCode.A))
            {
                rotation_center = transform.position + new Vector3(0, -size.y/2, size.x/2);
                rotation_direction = Vector3.right;
                return;
            }
            if(Input.GetKey(KeyCode.D))
            {
                rotation_center = transform.position + new Vector3(0, -size.y/2, -size.x/2);
                rotation_direction = Vector3.left;
                return;
            }
            is_move = false;
        }
    }
}
