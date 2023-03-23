using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    public GameObject couch;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float playerCouchDistance = Mathf.Abs(couch.transform.position.x - transform.position.x);
        float playerCouchHeightDistance = Mathf.Abs(couch.transform.position.y - transform.position.y);
        if ((playerCouchDistance < 2) || (playerCouchHeightDistance < 0.5)) {
            if (Input.GetKey(KeyCode.F)) {
                couch.transform.position = new Vector3(transform.position.x, couch.transform.position.y, couch.transform.position.z);
            }
        }
        // Movement 
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
    }
}
