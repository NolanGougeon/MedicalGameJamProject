using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] float damages = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyWeapon", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
            return;

        if(other.gameObject.CompareTag("Ennemi"))
        {
            
            other.gameObject.GetComponent<EnnemiController>().TakeDamages(damages);
            DestroyWeapon();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("8"))
            collision.gameObject.GetComponent<EnnemiController>().TakeDamages(damages);
    }

    protected void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
