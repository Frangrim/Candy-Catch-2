using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class VeggieScript : MonoBehaviour
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
        if (col.gameObject.tag == "Player") // If the veggie collides with the Player
        {
            GameManager.instance.DecrementScore(); // Calling the DECREASE score function from the GameManager

            Destroy(gameObject); // Destroy the candy
        }

        else if (col.gameObject.tag == "Boundary") // If the veggie collides with the Boundary
        {
            // GameManager.instance.DecrementLives(); // Not decrementing lives if the veggie falls off the screen.
            Destroy(gameObject); // Destroy the veggie
        }
    }
}
