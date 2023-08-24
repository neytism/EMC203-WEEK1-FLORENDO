using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform goalObject;
    public float minDistance = 5;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckDistanceFromGoal();
    }

    public void Move()
    {
        float moveX = transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float moveY = transform.position.z + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector3(moveX, transform.position.y, moveY);
    }

    public void CheckDistanceFromGoal()
    {
        float distance = Distance(transform.position, goalObject.position);

        if (distance < minDistance)
        {
            Debug.Log("TAPOS NA");
        }
    }
    
    private float Distance(Vector3 firstPos, Vector3 secondPos)
    {
        float xDifference = firstPos.x - secondPos.x;
        float yDifference = firstPos.y - secondPos.y;
        float zDifference = firstPos.z - secondPos.z;
        
        return Mathf.Sqrt(Mathf.Pow((xDifference), 2) + Mathf.Pow((yDifference), 2) + Mathf.Pow((zDifference), 2));
    }
}
