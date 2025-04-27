using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioClipSO audio;
    AudioSource musica;
    private void Awake()
    {
        musica = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            print("Entro");
            other.GetComponent<prota>().CambiarMusica(musica);
            audio.PlayOneShoot();
        }
    }
}
