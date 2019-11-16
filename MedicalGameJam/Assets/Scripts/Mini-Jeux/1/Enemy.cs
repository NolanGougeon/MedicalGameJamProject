using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Coroutine hover;
    Rigidbody2D m_rigibody;
    public Timer timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        m_rigibody = GetComponent<Rigidbody2D>();
        timer = new Timer(1f, randomMove);
        timer.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void randomMove()
    {
        float random = Random.Range(0, 2 * Mathf.PI);
        Vector2 randomVector = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
        m_rigibody.velocity = randomVector * speed;

        timer.ResetPlay();
    }
}
