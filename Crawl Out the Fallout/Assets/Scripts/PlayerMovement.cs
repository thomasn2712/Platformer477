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

    private float moveDir;
    private bool jump;
    private bool push;
    [SerializeField]
    public float speed;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        charCon = GetComponent<CharacterController2D>();
        push = false;
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
            push = true;
            animator.SetTrigger("Push");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Crouching");
        }


    }
    private void checkForRobot()
    {
        if (Vector3.Distance (transform.position, robot.transform.position) < 5){
            robot.GetComponent<Animator>().SetTrigger("Death");
        }
    }

    private void FixedUpdate(){
        charCon.Move(moveDir * speed * Time.fixedDeltaTime, false, jump);
        animator.SetFloat("Landing", Mathf.Abs(moveDir));
        jump = false;
    }


}
