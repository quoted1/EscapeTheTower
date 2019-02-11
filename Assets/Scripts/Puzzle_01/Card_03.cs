using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_03 : BoardSquare
{

    protected override void Awake()
    {
        base.Awake();
        images[1] = Resources.Load("Card_3") as Texture2D;
        Debug.Log("cardtextureadded");
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void onSquareSelected()
    {
        base.onSquareSelected();
    }

    protected override void updateEndGraphic()
    {
        base.updateEndGraphic();
    }

}