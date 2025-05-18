using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody2D rb;

    private AudioManager audioManager;
    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioManager = GetComponent<AudioManager>();
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    //we can get the input for a horizontal and vertical axis, which provides a value between
    //1 and -1 on the vertical and horizontal axis. We can then update the player's velocity
    //according to its direction and speed
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed *  Time.deltaTime;

        rb.linearVelocity = new Vector2(moveX, moveY);
    }

    //we can increase the size of the player everytime it consumes a collectible. We can also
    //add to its mass to make it slower
    public void Grow()
    {
        Vector3 newSize = transform.localScale + new Vector3(0.2f, 0.2f, 0);

        transform.localScale = newSize;

        //increases the player's mass every time they eat, making them slower
        rb.mass += 0.2f;

        //zooms the camera out everytime the player grows, so the player doesn't take up the whole screen
        //and we can still see where we're going and avoid obstacles.
        Camera.main.orthographicSize += 0.2f;

        //plays a munching sound everytime the player grows from collecting a collectible
        AudioClip clip = audioManager.SelectClip("Eat");

        source.PlayOneShot(clip);
    }
}
