using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Brekable, is_Spike, is_Platform;

    private void Awake()
    {
        if (is_Brekable)
        {
            //Animar
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 1f);
    }

    void DeactivateGameObject()
    {
        //Sonido Break
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000, 1000);
                //Sonido Muerte
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Brekable)
            {
                BreakableDeactivate();
                //Sonido plataforma
            }
            if (is_Platform)
            {
                //Sonido plataforma
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
