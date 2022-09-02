using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class MenuManager
{
    public static Dictionary<TypeOfMenu, GameObject> menusAndObjects = new Dictionary<TypeOfMenu, GameObject>();
    public static bool hasInit;

    public static void Initialise()
    {
        GameObject canvas = GameObject.Find("Canvas: Menus");
        if (!canvas) Debug.Log("CANVAS IS MISSING, PLEASE CHECK FOR SPELLING ERROR IN CANVASES");

        for(int i = 0; i < canvas.transform.childCount; i++)
        {
            menusAndObjects.Add(canvas.transform.GetChild(i).GetComponent<Menu>().typeOfMenu, canvas.transform.GetChild(i).gameObject);
        }
        hasInit = true;
    }

    public static void GoTo(TypeOfMenu to, GameObject callback)
    {
        if (!hasInit) Initialise();
        menusAndObjects[to].SetActive(true);
        callback.SetActive(false);
    } 
}