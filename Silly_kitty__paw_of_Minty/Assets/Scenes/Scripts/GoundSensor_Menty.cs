using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor_Menty : MonoBehaviour
{
    public bool isGrounded;
    public Animator anim;
    Gato_Menta Gato_Menta;

    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        Gato_Menta = GetComponentInParent<Gato_Menta>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Gato_Menta.rBody.AddForce(Vector2.up * Gato_Menta.jumpforce, ForceMode2D.Impulse);
        //anim.SetBool("IsJumping", true);
        isGrounded = true;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
        if (collider.gameObject.tag == "Antonia")
        {
            Destroy(collider.gameObject);
            //source.PlayOneShot(deathcatsound);
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
