using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn = 1f;

    //the number of obstacles and collectibles we want to spawn at
    //the start of the game
    public int obstacleCount;
    public int collectibleCount;

    //the level boundaries
    public Transform upperLevelBounds;
    public Transform lowerLevelBounds;

    //prefabs that we spawn clones of objects from
    public GameObject collectiblePrefab;
    public GameObject obstaclePrefab;

    //variables to be used to determine the minimum and maximum x and y values to spawn
    //items at, based on the level boundaries.
    private float minX, maxX;
    private float minY, maxY;
    //the temporary variable to be used for the timer
    private float spawnCountDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        //gets the minimum and maximum x and y values from the upper and lower level boundaries
        //so we can use it to spawn items into the level. We write it like this to keep the
        //code neat, readable and organised
        minX = upperLevelBounds.position.x;
        maxX = lowerLevelBounds.position.x;
        minY = lowerLevelBounds.position.y;
        maxY = upperLevelBounds.position.y;

        //initialise the timer. timeToSpawn is a variable that doesn't change and can be used to reset the
        //timer
        spawnCountDown = timeToSpawn;

        //this for loop is used to spawn the obstacles throughout the level using the boundaries that we have established.
        //So it will iterate through the loop, picking a new position to spawn the object until it reaches the obstacle
        //count. Ideally, we would also want it to check for an empty position before we spawn it.
        for (int i = 0; i < obstacleCount; i++)
        { 
            Instantiate(obstaclePrefab, DetermineSpawnPos(), Quaternion.identity);
        }

        //this for loop provides an initial spawn for the collectibles, so the player has something to collect from the
        //start of the game
        for (int i = 0; i < collectibleCount; i++)
        {
            Instantiate(collectiblePrefab, DetermineSpawnPos(), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    //the timer spawns new collectibles every few seconds, to ensure we always have something to collect
    void SpawnTimer()
    {
        //Time.deltaTime describes the interval in seconds from the last frame to the current one
        //we can use it to behave like a timer if we add it or subtract it from another variable
        spawnCountDown -= Time.deltaTime;
        print(spawnCountDown);

        //checks to see if the spawner count down has reached zero, then spawns a new collectible and
        //resets the timer
        if (spawnCountDown <= 0)
        {
            Instantiate(collectiblePrefab, DetermineSpawnPos(), Quaternion.identity);
            spawnCountDown = timeToSpawn;
        }

    }

    //instead of repeating this several times throughout the script, we can create a method that can be called
    //to initiate this piece of code. It picks a random spot between the boundaries we've given it to spawn a
    //collectible.
    Vector2 DetermineSpawnPos()
    {
        //we can find a coordinate on the x and y axis and spawn the collectible at that position. The code 
        //takes a random value between the minimum and maximum spaces of our boundaries (or the area between them)
        //and creates a coordinate to spawn it at
        float xPos = Random.Range(minX, maxX);
        float yPos = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(xPos, yPos);

        //we can then return this spawn position, which can be stored in a variable, or can just be used to represent
        //the vector
        return spawnPos;
    }
}
