using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask; // A layer mask so that a ray can be cast just at gameobjects on the floor layer
    float camRayLength = 100f; //length of the ray we cast from camera to scene 

    void Awake() //called regardless if script enabled or not so good for setting up references
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() //automatically called that fires every physics update
    {
        //raw axis has only values -1, 0, or 1. Allows player to get to full speed faster than GetAxis
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);    
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime; //deltaTime is time between each update call so changes movement to per second
        playerRigidbody.MovePosition(transform.position + movement); //move player
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //take point on screen and cast ray from that point forwards into scene
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) //casting the ray and checking if it has hit something or not
        {
            Vector3 playerToMouse = floorHit.point - transform.position; //apply this to make character turn
            playerToMouse.y = 0f; //dont allow character to lean back

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    public void stopMovement()
    {
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
