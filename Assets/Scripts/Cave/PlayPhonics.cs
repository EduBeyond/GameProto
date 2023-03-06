using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPhonics : MonoBehaviour
{
    public AudioSource src;
    public AudioClip audioClip;

    public void Clicked()
    {
        src.clip = audioClip;
        src.Play();
    }
}
