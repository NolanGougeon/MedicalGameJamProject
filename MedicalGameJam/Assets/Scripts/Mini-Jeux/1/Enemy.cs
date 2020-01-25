using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D m_rigibody;
    public Timer timer;
    public float speed;
    private bool isPlayerOnSight;
    public GameObject player;
    Vector3 targetScale;

    private AudioSource audioSource;
    [SerializeField] AudioClip eatSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        m_rigibody = GetComponent<Rigidbody2D>();
        timer = new Timer(2f, randomMove);
        timer.Play();
        targetScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 10);
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
