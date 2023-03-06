using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector3 direction;
    private float moveSpeed;

    [SerializeField] private ControlButton upButton, downButton, leftButton, rightButton;

    bool[] directionArrays = new bool[4];

    private List<GameObject> snakeBody;
    [SerializeField] private GameObject snakeBodyPrefab;

    private void Start()
    {
        Time.timeScale = 0.2f;
        moveSpeed = 1f;
        direction = new Vector3(moveSpeed, 0, 0);
        directionArrays[3] = true;
        snakeBody = new List<GameObject>();
        snakeBody.Add(this.gameObject);
    }

    private void Update()
    {
        Movement();
        ValidatePosition();
    }

    private void FixedUpdate()
    {
        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].transform.position = snakeBody[i - 1].transform.position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y, 0f);
    }

    private void Movement()
    {
        if (upButton.GetPressed() && !directionArrays[1])
        {
            direction = new Vector3(0, moveSpeed, 0);
            SetDirection(0);
        }
        else if(downButton.GetPressed() && !directionArrays[0])
        {
            direction = new Vector3(0, moveSpeed * (-1), 0);
            SetDirection(1);
        }
        else if(leftButton.GetPressed() && !directionArrays[3])
        {
            direction = new Vector3(moveSpeed * (-1), 0, 0);
            SetDirection(2);
        }
        else if(rightButton.GetPressed() && !directionArrays[2])
        {
            direction = new Vector3(moveSpeed, 0, 0);
            SetDirection(3);
        }
    }

    private void SetDirection(int s)
    {
        for(int i = 0; i < 4; i++)
        {
            directionArrays[i] = false;
        }
        directionArrays[s] = true;
    }

    private void ValidatePosition()
    {
        Vector2 upperLimit = new Vector2(26, 20);
        Vector2 lowerLimit = new Vector2(-6, 0);

        if (this.transform.position.x > upperLimit.x)
        {
            this.transform.position = new Vector3(lowerLimit.x, transform.position.y, transform.position.z);
        }
        if (this.transform.position.x < lowerLimit.x)
        {
            this.transform.position = new Vector3(upperLimit.x, transform.position.y, transform.position.z);
        }
        if (this.transform.position.y > upperLimit.y)
        {
            this.transform.position = new Vector3(transform.position.x, lowerLimit.y, transform.position.z);
        }
        if (this.transform.position.y < lowerLimit.y)
        {
            this.transform.position = new Vector3(transform.position.x, upperLimit.y, transform.position.z);
        }
    }

    private void Grow()
    {
        GameObject segment = Instantiate(this.snakeBodyPrefab);
        segment.transform.position = snakeBody[snakeBody.Count - 1].transform.position;

        snakeBody.Add(segment);
    }

    private void Shrink()
    {
        Destroy(snakeBody[snakeBody.Count - 1]);
        snakeBody.RemoveAt(snakeBody.Count - 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FoodGainer"))
        {
            Grow();
        }

        if (collision.CompareTag("FoodBurner"))
        {
            if (snakeBody.Count > 1)
            {
                Shrink();
            }
        }
    }
}
