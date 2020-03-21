using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkgameaudio : MonoBehaviour
{
    public AudioSource tapaudio;
    public AudioSource dieaudio;
    public AudioSource scoreaudio;


    // Start is called before the first frame update
     void ondisabling()
    {
        tapaudio.enabled = false;
        dieaudio.enabled = false;
        scoreaudio.enabled = false;
    }
     void onenabling()
    {
        tapaudio.enabled = true;
        dieaudio.enabled = true;
        scoreaudio.enabled = true;
    }
    public void check()
    {
        if (tapaudio.enabled)
        {
            ondisabling();
        }
        else
        {
            onenabling();
        }
    }

    // Update is called once per frame

}
