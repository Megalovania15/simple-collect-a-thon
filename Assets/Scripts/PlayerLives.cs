using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int playerLivesCount = 3;
    public GameObject deathParticle;
    public TMP_Text playerLivesText;

    private AudioManager audioManager;
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLivesText.text = "X" + playerLivesCount.ToString();

        audioManager = GetComponent<AudioManager>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //a method to call whenever the player bumps into an object, or if we were to extend it
    //when an enemy eats the player.
    public void Death()
    {
        AudioClip clip = audioManager.SelectClip("Die");

        source.PlayOneShot(clip);

        //spawn a particle effect when the player dies
        Instantiate(deathParticle, transform.position, Quaternion.identity);

        //turn the object off if we bump into an obstacle
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        
        //delete the gameObject from the scene after 0.4 seconds, the length it takes to play the death sound
        Destroy(gameObject, 0.4f);
    }

    /*public void LoseLife()
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
    }*/

    /*public void RespawnPlayer()
    {
        gameObject.SetActive(true);
    }*/
}
