using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogo
{
    public Sprite sprite;
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
