using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Data SO", menuName = "Scriptable Objects/Audio/Audio Data")]

public class AudioData : ScriptableObject
{
    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip => audioClip;
}