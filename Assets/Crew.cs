using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{ 
    public string name = "MPC Crew";
    public int age;
    public string gender;

    public Vector2 position;

    public Crew(string name, int age, string gender)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
        //init position to zero
        this.position = Vector2.zero;
    }

    // A public method to get the name of the character
    public string GetName()

    {
        return name;
    }

    // A public method to set the name of the character
    public void SetName(string newName)
    {
        name = newName;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DoWork();
    }

    public void DoWork()
    {
        //Debug.Log("Crew in working start");
    }

    //Walk method
    public void Walk(string direction)
    {
        if (direction == "right")
        {
            //move unit to the right
            this.position.x += 1;
            Debug.Log($"{this.name} moved to the right.");
        }
        else if (direction == "left")
        {
            //move unit to the left
            this.position.x -= 1;
            Debug.Log($"{this.name} moved to the left.");
        }
        else if (direction == "up")
        {
            //move unit to the up
            this.position.y += 1;
            Debug.Log($"{this.name} moved to the up.");

        }
        else if (direction == "down")
        {
            //move unit to the down
            this.position.y -= 1;
            Debug.Log($"{this.name} moved to the down.");
        }
        else 
        {
            //print an error message
            Debug.Log($"Invalid direction: {direction}.");
        }
    }
}
