using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnnemiController : MonoBehaviour
{
    
    [SerializeField] float lifePoint;
    public float LifePoint { get { return lifePoint; } }

    Rigidbody2D m_rigibody;


    private AudioSource audioSource;
    [SerializeField] AudioClip bumpSound, dieSound;
    [SerializeField] SoundEffectPlayer dieSoundPlayer;

    void Awake()
    {
        m_rigibody = this.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        //this.transform.position = new Vector3(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-1, 2), 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        float startForce = 2;
        float randAngle = UnityEngine.Random.Range(0f, 360f);
        m_rigibody.AddForce(new Vector2(startForce*Mathf.Cos(randAngle), startForce*Mathf.Sin(randAngle)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    { 
       
        
        if (CheckHP())
        {
            Dies();
        }
    }

    private bool CheckHP()
    {
        return lifePoint <= 0;
    }

    public void TakeDamages(float damages)
    {
        if (damages <= 0)
            return;
        lifePoint -= damages;

        if (lifePoint <= 0)
            Dies();   
    }

    private void Dies()
    {
        SoundEffectPlayer soundPlayer = Instantiate(dieSoundPlayer, transform.position, transform.rotation);
        soundPlayer.soundEffect = dieSound;
        soundPlayer.Play();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound(bumpSound);
    }


    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }

    /*public void MoveTowardsPosition(Vector3 targetPosition)
    {
        Vector3 direction = (Vector3)(targetPosition - rigidbody.position).normalized;
        rigidbody.MovePosition(rigidbody.position + direction * walkingSpeed * Time.fixedDeltaTime);
    }

    public void LookAtPoint(Vector3 pointToLookAt)
    {
        Vector3 direction = (Vector3)(pointToLookAt - rigidbody.position).normalized;
        rigidbody.MoveRotation(Quaternion.LookRotation(direction));
    }*/


}
