using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TypeOfMenu typeOfMenu;
}

public enum TypeOfMenu {Main, Level, Settings, Pause, Over, Complete}