using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D m_rigibody;
    public Timer timer;
    public float speed;
    private bool isPlayerOnSight;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        m_rigibody = GetComponent<Rigidbody2D>();
        timer = new Timer(2f, randomMove);
        timer.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void randomMove()
    {
        if (!m_rigibody)
        {
            return;
        }
        float random = Random.Range(0, 2 * Mathf.PI);
        Vector2 randomVector = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
        m_rigibody.velocity = randomVector * speed;

        timer.ResetPlay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Food" || collision.gameObject.tag == "Player")
        {
            float scale_x = collision.gameObject.transform.localScale.x;
            float scale_y = collision.gameObject.transform.localScale.y;
            if (scale_x < transform.localScale.x && scale_y < transform.localScale.y)
            {
                transform.localScale += new Vector3(scale_x, scale_y, 0);
                //GetComponent<CircleCollider2D>

                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Enemy>().timer.Pause();
                    AgarioManager.instance.listEnemy.Remove(collision.gameObject);
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
