using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Trampa : MonoBehaviour
{
    private AudioSource source;

    private BoxCollider2D boxCollider2D;

    public AudioClip TrampaSound;
    public AudioClip deathcatsound;

    //private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        //gameManager = GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            source.PlayOneShot(deathcatsound);
            SceneManager.LoadScene("GameOver");
        }

    }

    /*public void GoombaDeath()
    {
        source.PlayOneShot(deathSound);
        boxCollider2D.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject, 0.5f);
    }*/
}
