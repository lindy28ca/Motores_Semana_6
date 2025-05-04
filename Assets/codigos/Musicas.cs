using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioData audioData;
    AudioSource musica;
    private void Awake()
    {
        musica = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioClip clip = audioData.AudioClip;
            musica.PlayOneShot(clip);
            StartCoroutine(SceneTransitionManager.Instance.FadeEffect());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            musica.Stop();
            StartCoroutine(SceneTransitionManager.Instance.FadeEffect());
        }
    }
}