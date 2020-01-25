using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rigibody;
    public float speed = 50;
    Vector3 targetScale;

    Vector2 mp;

    private AudioSource audioSource;
    [SerializeField] AudioClip eatSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        m_rigibody = GetComponent<Rigidbody2D>();
        targetScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            mp = Camera.main.ScreenToWorldPoint(touch.position);

        }
        if(Input.GetMouseButton(0))
            mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            m_rigibody.MovePosition(Vector2.MoveTowards(m_rigibody.position, mp, speed * Time.fixedDeltaTime));
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
            if (scale_x <= transform.localScale.x && scale_y <= transform.localScale.y)
            {
                targetScale += new Vector3(scale_x, scale_y, 0);

                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<Enemy>().timer.Pause();
                    AgarioManager.instance.listEnemy.Remove(collision.gameObject);
                }
                Destroy(collision.gameObject);
            }

            audioSource.clip = eatSound;
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }

    }
}
