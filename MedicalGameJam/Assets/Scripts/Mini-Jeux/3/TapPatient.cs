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

    public override void Tap()
    {
        SoundPlayer.Instance.PlayWinSound();
        Instantiate(spriteFeedback[0], transform.position, Quaternion.identity);
        base.Tap();
    }

    protected override void Disappear()
    {
        CounterController.score -= malus;
        SoundPlayer.Instance.PlayLoseSound();
        Instantiate(spriteFeedback[2], transform.position, Quaternion.identity);
        base.Disappear();
    }
}
