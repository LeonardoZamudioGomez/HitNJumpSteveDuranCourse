using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int ScoreGive = 50; // The score that will add to our score.

    void OnTriggerEnter2D(Collider2D other) // Unity function to detect when it enters with a trigger.
    {
        if (other.gameObject.CompareTag("User")) // It should only be detected when an object with the user tag collides.
        {
            Game.obj.AddScore(ScoreGive); // We increase the score.

            User.obj.AddLive(); // Add life to the user from the user singleton.

            gameObject.SetActive(false); // Once they are taken, destroy them.
        }
    }
}
 