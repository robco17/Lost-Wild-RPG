using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

// Most of this script was used from Brackey's 1st & 3rd Person Movement videos.
// https://www.youtube.com/watch?v=_QajrabyTJc & https://www.youtube.com/watch?v=4HpC--2iowE
public class ThirdPersonMovement : MonoBehaviour
{
    // Declare the variables.
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public float speed = 7f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -19.62f;
    public float jumpHeight = 2f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    [HideInInspector] public bool isMoving = false;
    Vector3 velocity;
    [HideInInspector] public bool isGrounded;
    public bool canMove = true;
    public Animator anim;
    public GameObject player;
    public float Health = 100f;
    public Flowchart myFlowchart;
    public int numberOfEnemies;
    public GameObject deathScreen;
    public int isTalking = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Screen.lockCursor = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        // This shows if the character is touching the ground. Also resets the velocity back to normal.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Gets the movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Set the Float value of the Animator
        float magnitude = direction.magnitude;
        anim.SetFloat("MoveSpeed", magnitude * speed);
        MovementChecking(direction);

        // Restricts movement when in conversation.
        if (!canMove)
        {
            direction = Vector3.zero;
        }
        
        // Has the player move in the direction of the camera.
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Allows the character to jump using the Space Bar.
        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Implementing the gravity system, it is constantly falling.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Finds the number of enemies left (alive).
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        myFlowchart.SetIntegerVariable("numberOfEnemies", numberOfEnemies);

        // When the character dies, set the death animation and restrict movement.
        if (Health == 0f)
        {
            // Displays the death screen on death.
            deathScreen.SetActive(true);
            anim.SetBool("death2", true);
            canMove = false;
            ShowCursor();
        }

        // Restricts movement when talking with NPCs
        myFlowchart.SetIntegerVariable("isTalking", isTalking);
        if (isTalking == 1)
        {
            canMove = false;
        }

        if (isTalking == 0)
        {
            canMove = true;
        }
    }

    // Checks if the user is currently moving or standing still.
    void MovementChecking(Vector3 playerDirection)
    {
        if (playerDirection != Vector3.zero && isGrounded)
        {
            isMoving = true;
            //Debug.Log("The player is moving " + isMoving);
        }
        else if (playerDirection == Vector3.zero && isGrounded)
        {
            isMoving = false;
            //Debug.Log("The player is not moving " + isMoving);
        }
    }

    // Player damaged by projectile
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyMagic")) {
            Health -= 10f;
        }
    }

    // If the player is within the trigger box; then talk to the NPC accordingly.
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Simon" && Input.GetKeyDown(KeyCode.E))
        {
            myFlowchart.ExecuteBlock("Simon");
        }

        if (other.gameObject.tag == "Claire" && Input.GetKeyDown(KeyCode.E))
        {
            myFlowchart.ExecuteBlock("Claire");
        }

        if (other.gameObject.tag == "Victor" && Input.GetKeyDown(KeyCode.E))
        {
            myFlowchart.ExecuteBlock("Victor");
        }

        if (other.gameObject.tag == "Grandma" && Input.GetKeyDown(KeyCode.E))
        {
            myFlowchart.ExecuteBlock("Grandma");
        }

        if (other.gameObject.tag == "Tommy" && Input.GetKeyDown(KeyCode.E))
        {
            myFlowchart.ExecuteBlock("Tommy");
        }
    }

    // Hides & centers the mouse.
    public void ShowCursor()
    {
        Screen.lockCursor = false;
    }

    // Shows and allows the cursor to move around on the screen.
    public void HideCursor()
    {
        Screen.lockCursor = true;
    }
}