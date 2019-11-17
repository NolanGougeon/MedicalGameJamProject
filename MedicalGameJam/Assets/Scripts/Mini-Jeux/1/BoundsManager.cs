using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsManager : MonoBehaviour
{
    public static BoundsManager instance;
    public GameObject boundsUp;
    public GameObject boundsBot;
    public GameObject boundsLeft;
    public GameObject boundsRight;
    // Start is called before the first frame update
    void Start()
    {
        SetStaticInstance();
        SetBoundsPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoundsPosition()
    {
        int camHeight = Camera.main.pixelHeight;
        int camWidth = Camera.main.pixelWidth;

        boundsUp.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0.5f * camWidth, camHeight));
        boundsBot.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0.5f * camWidth, 0));
        boundsLeft.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, 0.5f * camHeight));
        boundsRight.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(camWidth, 0.5f * camHeight));
    }

    private void SetStaticInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Debug.Log("There are multiple BoundsManager instances");
    }
}
