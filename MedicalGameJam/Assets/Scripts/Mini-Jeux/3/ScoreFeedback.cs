using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ScoreFeedback : MonoBehaviour
{
    SpriteRenderer renderer;
    float lifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 1 * Time.deltaTime, 0);
    }
}
