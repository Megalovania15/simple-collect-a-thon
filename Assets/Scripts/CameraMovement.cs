using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    public float followDelay = 0.2f;

    private GameObject target;

    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find our player so we can keep track of it
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //find the x and y positions of our player target. Doing this helps keep the code readable
        /*float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;*/

        //we can set the camera's movement to the player's position, but we will not be able to tell
        //if the player is moving
        //transform.position = new Vector3(targetX, targetY, transform.position.z);

        //we can add an interpolation to the camera so it follows the player with a little bit of a 
        //delay. But it jitters when it is placed in update, so we can move it to FixedUpdate
        /*Vector3 targetPos = new Vector3(targetX, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, followDelay);*/
    }

    void FixedUpdate()
    {
        //find the x and y positions of our player target. Doing this helps keep the code readable
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;

        //we can add an interpolation to the camera so it follows the player with a little bit of a 
        //delay.
        Vector3 targetPos = new Vector3(targetX, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, followDelay);
    }
}
