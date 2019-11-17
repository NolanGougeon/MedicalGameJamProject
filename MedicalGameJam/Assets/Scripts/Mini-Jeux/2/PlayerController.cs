using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Transform m_Transform;
    Rigidbody m_Rigidbody;
   
   

    bool lookingRight = true;

    ///WEAPON HANDLING
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Canvas canva;
    [SerializeField] TextMeshProUGUI vaccinUsed;
    [SerializeField] float fireRate=.25f;
    private float timeNextThrow;
     public float mLUsed;
    [SerializeField] float throwForce = 1000.0f;
    

    private void Awake()
    {
        m_Transform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
      

        timeNextThrow = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

 

    private void Update()
    {
       
      
       
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        UpdateFacingDirection();
        if (Input.GetButtonDown("Fire1"))
        {
            mLUsed += 1;
            FireProjectile();
            UpdateTextMesh();
            
        }
    }

    private void UpdateTextMesh()
    {
        
        vaccinUsed.SetText(mLUsed + " mL used");
       //canva.GetComponent<TextMeshPro>().GetComponent<TextMeshProUGUI>().SetText();



    }

    private void FireProjectile()
    {
        GameObject tmp = Instantiate(weaponPrefab, firePoint.position, firePoint.rotation) as GameObject;
        tmp.GetComponent<Rigidbody2D>().velocity = firePoint.up * 10f;
       // timeNextThrow = Time.time + fireRate;
    }

    private void UpdateFacingDirection()
    {
        float hInputRaw = Input.GetAxisRaw("Horizontal");
        if (hInputRaw > 0)
            lookingRight = true;
        else if(hInputRaw < 0)
            lookingRight = false;
    }

    
}
