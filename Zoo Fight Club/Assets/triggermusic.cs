using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggermusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip newMusic;
    [SerializeField]
    bool hasPlayed = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && hasPlayed == false)
        {
            audioSource.clip = newMusic;
            audioSource.Play();
            hasPlayed = true; 
        }
    }
}
