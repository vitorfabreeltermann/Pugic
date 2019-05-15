using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TeamMenu : MonoBehaviour
{
    public SpriteRenderer ControlerFormation;
    public GameObject op;
    public bool _valuesStarted = false;
    public float PosX { get; private set; }
    public float PosY { get; private set; }
    public Color color { get; private set; }
    public void StartValues(float x, float  y, Color color)
    {
        if (!_valuesStarted)
        {
            PosX = x;
            PosY = y;
            ControlerFormation.color = this.color = color;
            _valuesStarted = true;
        }
    }
}
