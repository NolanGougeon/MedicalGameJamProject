using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rigibody;
    public float speed = 50;
    Vector2 mp;
    // Start is called before the first frame update
    void Start()
    {
        m_rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            m_rigibody.MovePosition(Vector2.MoveTowards(m_rigibody.position, mp, speed * Time.fixedDeltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Food")
        {
            float scale_x = collision.gameObject.transform.localScale.x;
            float scale_y = collision.gameObject.transform.localScale.y;
            if (scale_x < transform.localScale.x && scale_y < transform.localScale.y)
            {
                transform.localScale += new Vector3(scale_x, scale_y, 0);
                Destroy(collision.gameObject);
            }
        }
    }
}
