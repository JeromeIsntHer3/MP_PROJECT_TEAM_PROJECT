using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static Dictionary<TypeOfMenu, GameObject> menusAndObjects = new Dictionary<TypeOfMenu, GameObject>();
    public static bool hasInit;

    public static void Initialise()
    {
        GameObject parent = GameObject.Find("Canvas: Menus");
        hasInit = true;
        if (!parent) Debug.Log("CANVAS IS MISSING, PLEASE CHECK FOR SPELLING ERROR IN CANVASES");
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).GetComponent<Menu>() == null) return;
            menusAndObjects.Add(parent.transform.GetChild(i).GetComponent<Menu>().typeOfMenu, parent.transform.GetChild(i).gameObject);
            Debug.Log(parent.transform.GetChild(i).GetComponent<Menu>().typeOfMenu + " " + parent.transform.GetChild(i).gameObject.name);
        }
    }

    public static void GoTo(TypeOfMenu to, GameObject callback)
    {
        if (!hasInit) Initialise();
        menusAndObjects[to].SetActive(true);
        callback.SetActive(false);
    }
}