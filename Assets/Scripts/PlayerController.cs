using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    
    Rigidbody rb;
    bool isShiftKeyDown;
   // public GameObject[] goal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
      // goal = GameObject.FindGameObjectsWithTag("Goal");

    }


    void Update()
    {
        // PlayerMove();
        isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        rb.velocity = new Vector3(horizontal * speed, 0.0f, vertical * speed);


        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(0,  speed, 0);
        }
        if (isShiftKeyDown)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }

    }

    void OnTriggerEnter(Collider theCollision) 
    {
        if (theCollision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Player Passed");
        }
    }
}