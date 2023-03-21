using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
            // Movement 
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

        
    }
}
