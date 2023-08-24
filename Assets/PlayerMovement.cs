using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform goalObject;
    public float minDistance = 1;

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

        float distance = Distance(transform, goalObject);

        if (distance < minDistance)
        {
            Debug.Log("TAPOS NA");
        }
    }
    
    private float Distance(Transform firstPos, Transform secondPos)
    {
        return Mathf.Sqrt(Mathf.Pow((firstPos.position.x - secondPos.position.x), 2) + Mathf.Pow((firstPos.position.y - secondPos.position.y), 2) + Mathf.Pow((firstPos.position.z - secondPos.position.z), 2));
    }
}
