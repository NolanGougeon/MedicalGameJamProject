using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPatient : TapCharacter
{
    public static int malus = 5;


    // Update is called once per frame
    /*override protected void Update()
    {
        base.Update();
    }*/

    protected override void Disappear()
    {
        CounterController.score -= malus;
        base.Disappear();
    }
}
