using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject reality;
    [SerializeField] private GameObject body;

    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject cam2;

    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        ChangePerspectives();
    }

    void ChangePerspectives()
    {
        if (!playerInput.swapPerspective)
        {
            reality.SetActive(true);
            cam1.SetActive(true);
            cam2.SetActive(false);
            body.SetActive(false);
        }
        else
        {
            reality.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(true);
            body.SetActive(true);
        }
    } 
}