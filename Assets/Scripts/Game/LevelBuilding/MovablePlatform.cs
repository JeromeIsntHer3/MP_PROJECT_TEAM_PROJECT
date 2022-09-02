using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] movementPositions;
    private int currPosIndex = 0;

    void Start()
    {
        InvokeRepeating("Move", 1, 5);
    }

    void Move()
    {
        LeanTween.move(gameObject, movementPositions[currPosIndex], 4);
        GoToNext();
    }

    void GoToNext()
    {
        if(currPosIndex == movementPositions.Length-1)
        {
            currPosIndex = 0;
        }
        else
        {
            currPosIndex++;
        }
    }
}