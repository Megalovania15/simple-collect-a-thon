using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int playerLivesCount = 3;
    public GameObject deathParticle;
    public TMP_Text playerLivesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLivesText.text = "X" + playerLivesCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        //spawn a particle effect when the player dies
        Instantiate(deathParticle, transform.position, Quaternion.identity);

        //turn the object off if we bump into an obstacle
        gameObject.SetActive(false);
    }

    public void LoseLife()
    {
        //check to see if we have lives to lose first, and then lose a life and show the result
        //in the UI.
        if (playerLivesCount >= 0)
        {
            playerLivesCount--;
            playerLivesText.text = "X" + playerLivesCount.ToString();
            Death();
        }
        else 
        {
            print("Game Over");
        }
    }

    public void RespawnPlayer()
    {
        gameObject.SetActive(true);
    }
}
