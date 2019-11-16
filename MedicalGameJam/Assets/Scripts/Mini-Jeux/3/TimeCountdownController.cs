using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdownController : MonoBehaviour
{
    [SerializeField] float countdown = 30.0f;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        UpdateLifeSpanTapCharacter();

        text.text = "" + ((int)countdown+1);
        if(countdown<-0.2)
        {
            TapPatientGameManager.Instance.GameOver();
            text.text = "0";
        }
    }

    private void UpdateLifeSpanTapCharacter()
    {
        if(countdown<10f)
        {
            TapCharacter.startLifeSpan = 1.8f;
        }
        else if(countdown<20f)
        {
            TapCharacter.startLifeSpan = 2.3f;
        }
    }
}
