using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato_Menta : MonoBehaviour
{
    public Rigidbody2D rBody;

    public float movementSpeed = 15;
    public float jumpforce = 5;
    public bool jump = false;
    private float inputHorizontal;
    public SpriteRenderer render;
    public Vector3 newPosition = new Vector3(50, 5, 0);
    
    public Animator anim;
    
    public GroundSensor_Menty sensor;

    AudioSource source;
    public AudioClip jumpSound;
    


    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");

        Movement();
        Jump();
    }

    void Movement()
    {
        if (inputHorizontal< 0)
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if (inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && sensor.isGrounded == true)
        {

            if (sensor.isGrounded)
            {
                rBody.AddForce(new Vector2(0, 1) * jumpforce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
                source.PlayOneShot(jumpSound);
            }
            else if (sensor.isGrounded == true)
            {
                anim.SetBool("IsJumping", false);
            }

        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y);
    }
}