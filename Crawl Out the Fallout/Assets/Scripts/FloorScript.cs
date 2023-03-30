using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public Animator animator;


    AnimatorStateInfo animStateInfo;
    public float NTime;
    bool animationFinished = false;



 
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        NTime = animStateInfo.normalizedTime;
        if (NTime > 1.0f) animationFinished = true;
        if (animationFinished)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Player"))
        {
            animator.enabled = true;
        }
    }
}
