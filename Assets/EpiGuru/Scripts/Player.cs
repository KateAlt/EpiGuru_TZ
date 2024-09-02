using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float boardMove;
    [SerializeField] private float sensibilityMove;
    private bool canMove = true;

    public static event Action<string> GameOff;
    public static event Action AddPoint;

    void Update()
    {
        if(canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * speedMove * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x;

                Vector3 moveDirection = new Vector3(touchDeltaX * sensibilityMove, 0f, 0f);
                transform.Translate(moveDirection);

                Vector3 currentPosition = transform.position;
                currentPosition.x = Mathf.Clamp(currentPosition.x, -boardMove, boardMove);
                transform.position = currentPosition;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            GameOff?.Invoke("YOU FALL");
        }

        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddPoint?.Invoke();
        }

        if(other.CompareTag("Finish"))
        {
            GameOff?.Invoke("YOU WIN");
        }
    }

    public void SetState(bool value)
    {
        canMove = value;
    }
}
