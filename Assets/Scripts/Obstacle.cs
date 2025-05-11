using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        //when the player collides with the obstacle, they either die or lose a life.
        //We need to get a reference to the player lives class on the player and
        //call the death or loseLife method from the class
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLives playerLives = other.gameObject.GetComponent<PlayerLives>();
            //playerLives.Death();
            playerLives.LoseLife();
        }
    }
}
