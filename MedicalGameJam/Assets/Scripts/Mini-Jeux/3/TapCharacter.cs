using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCharacter : MonoBehaviour
{
    public int value = 1;
    [SerializeField] public static float startLifeSpan = 3f;
    private float lifeSpan;
    public float lifeSpanStartFlashing = 1.0f;
    private float flashingRate = .13f;


    protected SpriteRenderer renderer;

    bool flashing = false;

    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        lifeSpan = startLifeSpan;
    }


    // Update is called once per frame
    virtual protected void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= lifeSpanStartFlashing && !flashing)
        {
            StartCoroutine("FlashSprite");
            flashing = true;
        }
        if (lifeSpan <= 0)
            Disappear();
    }

    protected virtual void Disappear()
    {
        Destroy(gameObject);
    }

    public void Tap()
    {
        CounterController.score += value;
        Destroy(gameObject);
    }

    IEnumerator FlashSprite()
    {
        bool spriteVisible = true;

        while(true)
        {
            spriteVisible = !spriteVisible;
            renderer.enabled = spriteVisible;
            yield return new WaitForSeconds(flashingRate);
        }
    }

    /*private void OnMouseDown()
    {
        Tap();
    }*/
}
