using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMedecin : TapCharacter
{
    public override void Tap()
    {
        SoundPlayer.Instance.PlayLoseSound();
        Instantiate(spriteFeedback[1], transform.position, Quaternion.identity);
        base.Tap();
    }
}
