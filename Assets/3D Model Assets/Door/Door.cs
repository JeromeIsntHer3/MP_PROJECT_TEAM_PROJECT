using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour
{
    private PlayableDirector director;

    void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            director.Play();
        }
    }
}