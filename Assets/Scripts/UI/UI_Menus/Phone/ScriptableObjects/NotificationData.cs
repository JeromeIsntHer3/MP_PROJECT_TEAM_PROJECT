using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationData : ScriptableObject
{
    public string header;
    [Multiline]
    public string info;
    public Color color;
    public bool seen = false;
}