using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Transform m_Transform;
    Rigidbody m_Rigidbody;

    Animation anim;

    bool lookingRight = true;

    ///WEAPON HANDLING
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Canvas canva;
    [SerializeField] TextMeshProUGUI vaccinUsed;
    [SerializeField] float fireRate=.25f;
    private float timeNextThrow;
    public float mLUsed;
    public float mLMaxUsed=12.0f;
    [SerializeField] float throwForce = 1000.0f;

    private AudioSource audioSource;
    [SerializeField] AudioClip shootSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();

        timeNextThrow = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTextMesh();
    }

 

    private void Update()
    {
        UpdateFacingDirection();
        if (Input.GetButtonDown("Fire1"))
        {
            mLUsed += 1;
            GetComponent<Animator>().SetTrigger("Fire");
            FireProjectile();
            UpdateTextMesh();
        }
    }

    private void UpdateTextMesh()
    {
        
        vaccinUsed.SetText(mLUsed+"/"+mLMaxUsed + " mL used");
       //canva.GetComponent<TextMeshPro>().GetComponent<TextMeshProUGUI>().SetText();



    }

    private void FireProjectile()
    {
        GameObject tmp = Instantiate(weaponPrefab, firePoint.position, firePoint.rotation) as GameObject;
        tmp.GetComponent<Rigidbody2D>().velocity = firePoint.up * 10f;
        // timeNextThrow = Time.time + fireRate;
        audioSource.clip = shootSound;
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }

    private void UpdateFacingDirection()
    {
        float hInputRaw = Input.GetAxisRaw("Horizontal");
        if (hInputRaw > 0)
            lookingRight = true;
        else if(hInputRaw < 0)
            lookingRight = false;

        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector3 mp = Input.mousePosition;
        mp = Camera.main.ScreenToWorldPoint(mp);
        Vector2 direction = new Vector2(mp.x - transform.position.x, mp.y - transform.position.y);
        transform.up = direction;
    }

}
