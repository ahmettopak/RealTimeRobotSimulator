using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

    public float minZoom = 1f;
    public float maxZoom = 5f;
    public float zoomSenstive = 0.01f;
    public float zoomValue = 1f;
    public float moveSenstive = 0.3f;


    void Update()
    {
        if (Input.touchCount == 1) // Tek parmakla dokunma
        {
            Touch touchPoint = Input.GetTouch(0);

            // Döndürme
            if (touchPoint.phase == TouchPhase.Moved)
            {
                float rotX = touchPoint.deltaPosition.y * moveSenstive;
                float rotY = touchPoint.deltaPosition.x * moveSenstive;
             
                transform.Rotate(rotX, rotY, 0);
            }
        }
        else if (Input.touchCount == 2) // İki parmakla dokunma
        {
            Touch touchPoint1 = Input.GetTouch(0);
            Touch touchPoint2 = Input.GetTouch(1);

            // Zoom
            if (touchPoint1.phase == TouchPhase.Moved && touchPoint2.phase == TouchPhase.Moved)
            {
                float touchLenght = Vector2.Distance(touchPoint1.position, touchPoint2.position);
                float lateTouchLenght = Vector2.Distance(touchPoint1.position - touchPoint1.deltaPosition, touchPoint2.position - touchPoint2.deltaPosition);
                float fark = (touchLenght - lateTouchLenght) * zoomSenstive;
                zoomValue = Mathf.Clamp(zoomValue - fark, minZoom, maxZoom);
                transform.localScale = new Vector3(zoomValue, zoomValue, zoomValue);
            }
        }
   
    }
}
