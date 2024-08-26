using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Cola : MonoBehaviour
{
    public Logic logicScript;//script - Logic
    

    public bool keyCollected; //if key is collected

    public GameObject keyItem;
    
    public HPScript health;

    public Animator animator; //player animator component

    Rigidbody2D rb;

    public int speed; //speed of player movement

    Vector2 movement; //x,y


    private void Start()
    {
        transform.position = Vector3.zero; //spwan point
        keyCollected = false;
    }


    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Key")) //if it's key
        {
            KeyCollected(collision.gameObject); //get function keycollected from logic script and execute it
        }

        if (collision.CompareTag("Trap")) //if it's key
        {
            TakeDamage(collision.gameObject); //get function keycollected from logic script and execute it
        }

        //if (collision.CompareTag("Object")) //if it's key
        //{
        //    Collected(collision.gameObject); //get function keycollected from logic script and execute it
        //    //keyCollected = true;  //key is collected (bollen = true)
        //}

    }

    public void KeyCollected(GameObject key)
    {
        keyCollected = true;  //key is collected (bollen = true)
        Destroy(key.gameObject);
        Debug.Log("Key Collected!");
        keyItem.gameObject.SetActive(true);
    }

    public void Collected(GameObject obj)
    {
        Destroy(obj.gameObject);
        Debug.Log("Object Collected!");
        //keyItem.gameObject.SetActive(true);
    }

    public void TakeDamage(GameObject trap)
    {
        health.RemoveHeart();
        Debug.Log("damaged!");

        animator.SetTrigger("TakeDamage");
    }


    private void Awake() //execute once before the application starts.
    {
        rb = GetComponent<Rigidbody2D>();


    }


    
    void Update()// Update is called once per frame
    {

        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.y = Input.GetAxis("Vertical") * speed;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() //physics stuff
    {
        rb.velocity = new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
    }
}
