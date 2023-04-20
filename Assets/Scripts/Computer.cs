using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public AudioClip zero;
    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip five;
    public AudioClip six;
    public AudioClip seven;
    public AudioClip eight;
    public AudioClip nine;
    public AudioSource audio;
    


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            audio.Stop();
            audio.PlayOneShot(zero, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audio.Stop();
            audio.PlayOneShot(one, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audio.Stop();
            audio.PlayOneShot(two, 0.7F);
        }  
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audio.Stop();
            audio.PlayOneShot(three, 0.7F);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audio.Stop();
            audio.PlayOneShot(four, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            audio.Stop();
            audio.PlayOneShot(five, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            audio.Stop();
            audio.PlayOneShot(six, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            audio.Stop();
            audio.PlayOneShot(seven, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            audio.Stop();
            audio.PlayOneShot(eight, 0.7F);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            audio.Stop();
            audio.PlayOneShot(nine, 0.7F);
        }                     
    }
    // https://support.unity.com/hc/en-us/articles/
    // 206116386-How-do-I-play-multiple-Audio-Sources
    // -from-one-GameObject-

    // troubleshot some with ChatGPT, was not assisted
}