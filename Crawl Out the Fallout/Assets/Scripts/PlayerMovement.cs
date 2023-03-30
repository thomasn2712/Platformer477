using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D charCon;
    private Rigidbody2D rb = null;
    private Vector2 moveVector = Vector2.zero;
    public Animator animator;
    public GameObject robot;
    public GameObject robot2;
    public GameObject robot3;
    public GameObject pushable;
    public GameObject pushable2;
    public GameObject pushable3;

    private Rigidbody2D pushableRb;
    private Rigidbody2D pushableRb2;
    private Rigidbody2D pushableRb3;
    private BoxCollider2D playerCollider;
    private CapsuleCollider2D crouchCollider;


    private float moveDir;
    private bool jump;
    [SerializeField]
    public float speed;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        pushableRb = pushable.GetComponent<Rigidbody2D>();
        pushableRb2 = pushable2.GetComponent<Rigidbody2D>();
        pushableRb3 = pushable3.GetComponent<Rigidbody2D>();
        charCon = GetComponent<CharacterController2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        crouchCollider = GetComponent<CapsuleCollider2D>();
        jump = false;
    }

    private void Update()
    {
        moveDir = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetTrigger("Jumping");
        } 
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Kick");
            checkForRobot();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Push");
            checkForPush();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Crouching");
            changeCollider();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 50;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 30;
        }


    }
    private void checkForRobot()
    {
        if (Vector3.Distance (transform.position, robot.transform.position) < 5){
            robot.GetComponent<Animator>().SetTrigger("Death");
        }
        if (Vector3.Distance(transform.position, robot2.transform.position) < 5)
        {
            robot2.GetComponent<Animator>().SetTrigger("Death");
        }
        if (Vector3.Distance(transform.position, robot3.transform.position) < 5)
        {
            robot3.GetComponent<Animator>().SetTrigger("Death");
        }
    }
    private void checkForPush()
    {
        if (Vector3.Distance(transform.position, pushable.transform.position) < 3)
        {
            pushableRb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
        if (Vector3.Distance(transform.position, pushable2.transform.position) < 3)
        {
            pushableRb2.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
        if (Vector3.Distance(transform.position, pushable3.transform.position) < 3)
        {
            pushableRb3.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
    }
    private void changeCollider()
    {
        playerCollider.enabled = !playerCollider.enabled;
        crouchCollider.enabled = !crouchCollider.enabled;
    }

    private void FixedUpdate(){
        charCon.Move(moveDir * speed * Time.fixedDeltaTime, false, jump);
        animator.SetFloat("Landing", Mathf.Abs(moveDir));
        jump = false;
    }


}
