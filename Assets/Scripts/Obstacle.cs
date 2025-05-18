using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        //when the player collides with the obstacle, they die and spawn a game over screen
        //with a high score. We need to get a reference to the player lives class on the 
        //player and call the death method from the class
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLives playerLives = other.gameObject.GetComponent<PlayerLives>();
            playerLives.Death();
        }
    }
}
