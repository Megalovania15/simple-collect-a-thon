using UnityEngine;

public class Collectible : MonoBehaviour
{
    //an array of sprites to provide an assortment of items to collect
    public Sprite[] fruitSprites;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        //we can get a reference to the sprite renderer component on the collectible and randomise the
        //sprite that it is spawned with, to give the game a bit of variety.
        spriteRenderer = GetComponent<SpriteRenderer>();

        Sprite selectedSprite = fruitSprites[Random.Range(0, fruitSprites.Length)];

        spriteRenderer.sprite = selectedSprite;
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
