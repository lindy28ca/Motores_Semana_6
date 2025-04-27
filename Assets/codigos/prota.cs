using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class prota : MonoBehaviour
{
    Rigidbody protita;
    AudioSource Musica;
    public float velocidad;
    float movimientosx;
    float movimientosz;
    public AudioSource pasos;
    private bool pasosReproduciéndose = false;
    private void Awake()
    {
        protita = GetComponent<Rigidbody>();
        Musica = GetComponent<AudioSource>();
    }
    public void MovimientosX(InputAction.CallbackContext context)
    {
        movimientosx = context.ReadValue<float>();
    }
    public void MovimientosZ(InputAction.CallbackContext context)
    {
        movimientosz = context.ReadValue<float>();
    }
    private void Update()
    {
        if (protita.velocity.magnitude > 0.1f)
        {
            if (!pasosReproduciéndose)
            {
                pasos.Play();
                pasosReproduciéndose = true;
            }
        }
        else
        {
            if (pasosReproduciéndose)
            {
                pasos.Stop();
                pasosReproduciéndose = false;
            }
        }
    }
    private void FixedUpdate()
    {
        protita.velocity=new Vector3(movimientosx*velocidad,protita.velocity.y,movimientosz*velocidad);
    }
    public void CambiarMusica(AudioSource musica)
    {
        if(Musica.clip!=musica.clip)
        {
            Musica.clip=musica.clip;
            Musica.Play();
        }
    }
}
