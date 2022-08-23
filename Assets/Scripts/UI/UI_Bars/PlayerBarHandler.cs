using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarHandler : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider,healthSlider2, recoverySlider;

    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        healthSlider.value = player.GetStat(TypeOfStat.Health);
        healthSlider2.value = player.GetStat(TypeOfStat.Health);
        recoverySlider.value = player.GetStat(TypeOfStat.Recovery);
    }
}