using UnityEngine;

public class PlayerRespawnTimer : MonoBehaviour
{
    public float respawnTime = 3f;
    public bool startRespawn = false;

    private float elapsedTime;

    private PlayerLives player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (startRespawn)
        {
            elapsedTime = respawnTime - Time.deltaTime;
            print(elapsedTime);

            if (elapsedTime <= 0)
            {
                player.RespawnPlayer();
            }
        }*/
        
    }
}
