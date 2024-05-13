using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This code runs if a trigger (property of a 2D Collider)
    // is entered.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") // If the candy collides with the Player
        {
            GameManager.instance.IncrementScore(); // Calling the score function from the GameManager

            Destroy(gameObject); // Destroy the candy
        }
        else if (col.gameObject.tag == "Boundary") // If the candy collides with the Boundary
        {
            GameManager.instance.DecrementLives(); // Calling the lives function from the GameManager
            Destroy(gameObject); // Destroy the candy
        }
    }
}
