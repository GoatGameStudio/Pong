using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] int CPUSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < ball.transform.position.y) 
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * CPUSpeed;
        if(gameObject.transform.position.y > ball.transform.position.y)
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * CPUSpeed;
    }

    void FixedUpdate()
    {/*
        if (gameObject.transform.position.y < ball.transform.position.y)
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * CPUSpeed);
        if (gameObject.transform.position.y > ball.transform.position.y)
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * CPUSpeed);
    */}
}
