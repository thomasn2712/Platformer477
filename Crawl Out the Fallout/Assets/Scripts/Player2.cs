using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    private CharacterController2D charCon;
    private Rigidbody2D rb = null;
    private Vector2 moveVector = Vector2.zero;
    public Animator animator;

    private BoxCollider2D playerCollider;
    private CapsuleCollider2D crouchCollider;


    private float moveDir;
    private bool jump;
    [SerializeField]
    public float speed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Push");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Crouching");
            changeCollider();
        }


    }

    private void changeCollider()
    {
        playerCollider.enabled = !playerCollider.enabled;
        crouchCollider.enabled = !crouchCollider.enabled;
    }

    private void FixedUpdate()
    {
        charCon.Move(moveDir * speed * Time.fixedDeltaTime, false, jump);
        animator.SetFloat("Landing", Mathf.Abs(moveDir));
        jump = false;
    }


}
