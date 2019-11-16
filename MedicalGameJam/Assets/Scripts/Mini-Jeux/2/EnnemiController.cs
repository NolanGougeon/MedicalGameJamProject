using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiController : MonoBehaviour
{
    
    [SerializeField] float lifePoint;
    public float LifePoint { get { return lifePoint; } }

    Rigidbody2D m_rigibody;
    void Awake()
    {
        m_rigibody = this.GetComponent<Rigidbody2D>();

        this.transform.position = new Vector3(UnityEngine.Random.Range(-11, 12), UnityEngine.Random.Range(-7, 7), 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rigibody.inertia = 1;
       m_rigibody.velocity = Vector2.right * 10;
    }

    // Update is called once per frame
    void Update()
    { 
        
        
           
        if (Math.Abs(m_rigibody.velocity.x)>10 || Math.Abs(m_rigibody.velocity.y)>10)
        {
            
        }
        
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
        Destroy(gameObject);
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
