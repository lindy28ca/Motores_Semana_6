using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControladoreDemuscia : MonoBehaviour
{
    Slider Barra;
    public AudioMixerSO audio;
    private void Awake()
    {
        Barra = GetComponent<Slider>();
        Barra.value = audio.GetCurrentVolumeValue();
    }

}
