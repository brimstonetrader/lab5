using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegasMovement : MonoBehaviour

{
    public Rigidbody body;
    public float horizontal;
    public float vertical;

    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (horizontal != 0 || vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector3(horizontal * runSpeed, 0, vertical * runSpeed);
    }
}