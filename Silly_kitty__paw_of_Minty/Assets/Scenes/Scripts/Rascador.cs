using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rascador : MonoBehaviour
{
    public AudioClip lvl1Music;
    public AudioClip flag;

    AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.clip = lvl1Music;
        source.Play();
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        source.clip = flag;
        source.Play();

    }
}
