using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Menuscene : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool start = false;
    // Start is called before the first frame update

    public void Start()
    {
        start = false;
    }

    //check if the start button is press
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            start = true;
        }
    }

    //set the timeline timestamp to 3.8/233frame to create a loop
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

    //change to the next scene
    public void ChangeScene()
    {
        Debug.Log("changescene");
    }
}
