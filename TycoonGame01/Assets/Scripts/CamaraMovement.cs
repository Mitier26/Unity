using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.8f;
    [SerializeField] Transform leftBoarder;
    [SerializeField] Transform rightBoarder;

    public void Clamp(ref Vector3 value)
    {
        value.x = Mathf.Clamp(value.x, leftBoarder.position.x, rightBoarder.position.x);
        value.y = Mathf.Clamp(value.y, leftBoarder.position.y, rightBoarder.position.y);
        value.z = Mathf.Clamp(value.z, leftBoarder.position.z, rightBoarder.position.z);
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                Vector3 newPos = transform.position + new Vector3(0,0, -touchDeltaPosition.x * Time.deltaTime * speed);
            
                Clamp(ref newPos);
                transform.position = newPos;
            }
        }
    }
}
