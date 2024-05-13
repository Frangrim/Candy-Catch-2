using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This will let us enable/disable player movement.
    public bool canMove = true;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float maxPos;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        // The following code calculates movement based on location,
        // player input, move speed, and time and assigns that data
        // to the current position.

        //                                                            (1, 0, 0)
        transform.position += inputX * moveSpeed * Time.deltaTime * Vector3.right;

        // The Clamp() method "clamps" a value between a min and max
        // value. In this case we are using it to constrain the value
        // of the player movement to be within the edges of the screen.
        // All this code is just to give a min and max value to xPos.

        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        // This code uses the "clamped" value as the x position while
        // keeping the y and z positions the same to prevent the player
        // from moving outside the bounds of the game. In other words,
        // the x value cannot be greater than xPos or less than -xPos.

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
