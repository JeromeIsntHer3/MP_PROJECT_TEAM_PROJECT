using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField][Range(0, 100)] private int numberOfPlatforms;
    [SerializeField][Range(0, 100)] private float distanceFromPreviousLength;
    [SerializeField][Range(0, 100)] private float distanceFromPreviousWidth;
    [SerializeField][Range(0, 100)] private float chanceToHaveCoin;
    [SerializeField][Range(0, 100)] private float chanceToHaveBacteria;

    private Vector3 previousPlatform = new Vector3(0,0,0);
    public List<GameObject> previousPlatforms;

    void Start()
    {
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            int index = Random.Range(0, platformPrefabs.Length);

            GameObject temp = Instantiate(platformPrefabs[index],gameObject.transform);

            float xDist = Random.Range(-distanceFromPreviousLength, distanceFromPreviousLength);
            float yDist = Random.Range(-distanceFromPreviousWidth, distanceFromPreviousWidth);

            temp.transform.position = new Vector3(previousPlatform.x + xDist, previousPlatform.y + yDist);
            
            if(Vector3.Distance(temp.transform.position, previousPlatform) < 5)
            {
                float newXDist = Random.Range(-distanceFromPreviousLength, distanceFromPreviousLength);
                float newYDist = Random.Range(-distanceFromPreviousWidth, distanceFromPreviousWidth);

                temp.transform.position = new Vector3(previousPlatform.x + newXDist, previousPlatform.y + newYDist);
            }

            previousPlatform = temp.transform.position;
            previousPlatforms.Add(temp);
        }
    }
}