using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CharacterMenuAnimation : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public bool start = false;

    public void Start()
    {
        start = false;
    }

    public void Loop()
    {
        if (start == true)
        {
            playableDirector.Play();
        }
        else
        {
            playableDirector.time = 3.8;
            playableDirector.Play();
        }
    }
}
