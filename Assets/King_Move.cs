using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Move : MonoBehaviour
{
    public float moveSpeed;
    public GameObject visual;
    public Animator animPower;
    public Vector3 kingPosition;
    public float horizontal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.x > Screen.width * 0.5f)
            {
                horizontal = 1f;

            }
            else
            {
                horizontal = -1f;
            }
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        animPower.SetFloat("KingMovementSpeed", Mathf.Abs(horizontal));

        if (horizontal >= 0)
        {
            visual.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            visual.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += new Vector3(moveSpeed, 0, 0) * horizontal * Time.deltaTime;

        kingPosition = transform.position;

    }
}
