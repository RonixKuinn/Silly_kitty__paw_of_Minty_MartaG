using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antomia : MonoBehaviour
{
    private Rigidbody2D rBody;

    private AudioSource source;

    private BoxCollider2D boxCollider2D;

    public AudioClip deathSound;
    public AudioClip deathcatsound;

    public float enemySpeed = 5;
    public float enemyDirection = 1;
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);
    }

    /*public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 || collision.gameObject.tag == "Antonia")
        {
            if (enemyDirection == 1)
            {
                enemyDirection = -1;
            }
            else if (enemyDirection == -1)
            {
                enemyDirection = 1;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            source.PlayOneShot(deathcatsound);
            //SceneManager.LoadScene("GameOver");
        }

    }

    public void GoombaDeath()
    {
        source.PlayOneShot(deathSound);
        boxCollider2D.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject, 0.5f);
    }
}
