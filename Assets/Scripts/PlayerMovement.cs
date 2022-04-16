using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
    }

    public void PlatformMove (float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameManager.instance.addCoin();
        }
    }
}
