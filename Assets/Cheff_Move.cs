using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheff_Move : MonoBehaviour
{
    public int cheffTasks;
     
    private Vector3 pointA = Vector3.right;
    private Vector3 pointB = Vector3.up;
    private Vector3 pointC = Vector3.left;

    private Vector3 startPosition;
    private Vector3 currentTarget;

    public float moveSpeed = 1f;
    public float distance = 1f;

    public int moveCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tasks in move =  " + cheffTasks);
        startPosition = transform.position;
        currentTarget = startPosition + pointA * distance;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tasks in move =  " + cheffTasks);
        cheffTasks = PlayerPrefs.GetInt("CheffTasks");

        if (cheffTasks > 0)
        {
            // Move the object towards the current point
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
            // Check object is close enough to the current point
            if (transform.position == currentTarget)
            {
                moveCounter++;
                switch (moveCounter)
                {
                    case 1:
                        currentTarget = startPosition + pointB * distance;
                        break;
                    case 2:
                        currentTarget = startPosition + pointC * distance;
                        break;
                    case 3:
                        currentTarget = startPosition + pointA * distance;
                        break;
                    case 4:
                        currentTarget = startPosition;
                        moveCounter = 0;
                        break;
                }

            }
        }
    }
}
