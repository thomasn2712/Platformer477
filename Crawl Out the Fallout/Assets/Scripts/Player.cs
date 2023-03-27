using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float speed;

    private CharacterController2D charCon;
    private float moveDir;
    private bool jump;

    private void Start()
    {
        charCon = GetComponent<CharacterController2D>();
        jump = false;
    }

    private void Update()
    {
        moveDir = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Death");
        }
    }

    private void FixedUpdate()
    {
        charCon.Move(moveDir * speed * Time.fixedDeltaTime, false, jump);
        if (charCon.IsPlayerOnGround())
        {
            animator.SetTrigger("Grounded");
        }
        jump = false;
        animator.SetFloat("Idle", Mathf.Abs(moveDir));
    }
}



//float playerCouchDistance = Mathf.Abs(couch.transform.position.x - transform.position.x);
//float playerCouchHeightDistance = Mathf.Abs(couch.transform.position.y - transform.position.y);
//if ((playerCouchDistance < 2) && (playerCouchHeightDistance < 0.5))
//{
//    if (Input.GetKey(KeyCode.F))
//    {
//        couch.transform.position = new Vector3(transform.position.x, couch.transform.position.y, couch.transform.position.z);
//    }
//}
