using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //for collectibles we use a trigger so the player can move over them. We need references to the
    //player score script and the player controller script to update the player's score and grow the
    //player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            PlayerController controller = other.GetComponent<PlayerController>();

            playerScore.UpdateScore();
            controller.Grow();

            Destroy(gameObject);
        }
    }
}
