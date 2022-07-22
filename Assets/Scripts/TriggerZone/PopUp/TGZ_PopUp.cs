using UnityEngine;

public class TGZ_PopUp : TriggerZoneData
{
    public PopUp thisPopUp;

    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        PopUpHandler popUpHandler = FindObjectOfType<PopUpHandler>();
        popUpHandler.SetUpPopUp(thisPopUp);
    }
}