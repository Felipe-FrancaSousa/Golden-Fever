using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour
{
    public AudioSource[] MusicasAmbiente = new AudioSource[2];
    public static float Volume = 0.3f;

    public static void MudarVolume(float Vol)
    {
        Volume = Vol;
    }
    private void Update()
    {
        for (int i = 0; i < MusicasAmbiente.Length; i++)
        {
            MusicasAmbiente[i].volume = Volume;
        }  
    }


    
}
