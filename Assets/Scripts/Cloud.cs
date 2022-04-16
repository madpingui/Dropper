using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = -6f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y <= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }
}
