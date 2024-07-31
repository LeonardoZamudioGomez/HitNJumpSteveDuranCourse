using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("User")) // Unity function to detect when it enters with a collision.
        {
            Game.obj.GameOver(); // The GameOver function is called with the Game singleton.
        }
    }
}
