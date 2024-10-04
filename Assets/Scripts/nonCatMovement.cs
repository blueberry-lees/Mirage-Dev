using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonCatMovement : MonoBehaviour
{
    Vector2 movement;
    public float travelSpeed;
    public Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        movement.x = 0;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal")* travelSpeed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime;

    }
}
