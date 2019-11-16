using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hitInfo)
            {
                TapCharacter tmp = hitInfo.collider.gameObject.GetComponent<TapCharacter>();
                if (tmp != null)
                    tmp.Tap();
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Vector2.zero);
            if(hitInfo)
            {
                TapCharacter tmp = hitInfo.collider.gameObject.GetComponent<TapCharacter>();
                if (tmp != null)
                    tmp.Tap();
            }
        }
    }
}
