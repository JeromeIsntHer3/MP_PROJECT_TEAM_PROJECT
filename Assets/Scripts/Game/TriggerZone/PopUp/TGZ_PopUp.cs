using UnityEngine;

[CreateAssetMenu(fileName = "TriggerZone", menuName = "TriggerZoneData/Pop Up")]

public class TGZ_PopUp : TriggerZoneData
{
    public Vector3 popUpSize;
    public Vector3 popUpPosition;
    [Multiline]
    public string textToShow;
    public bool seen = false;

    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        if (seen) return;
        PopUp popUp = FindObjectOfType<PopUp>();
        popUp.SetUpPopUp(popUpPosition, popUpSize, textToShow);
        //seen = true;
    }
}