using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector2 baslangicDokunmaPozisyonu;
    public float minZoom = 1f;
    public float maxZoom = 5f;
    public float zoomSenstive = 0.01f;
    public float zoomValue = 1f;
    public float moveSenstive = 0.3f;


    void Update()
    {
        if (Input.touchCount == 1) // Tek parmakla dokunma
        {
            Touch dokunma = Input.GetTouch(0);

            // Döndürme
            if (dokunma.phase == TouchPhase.Moved)
            {
                float rotX = -dokunma.deltaPosition.y * moveSenstive;
                float rotY = dokunma.deltaPosition.x * moveSenstive;
                transform.Rotate(rotX, rotY, 0);
            }
        }
        else if (Input.touchCount == 2) // İki parmakla dokunma
        {
            Touch dokunma1 = Input.GetTouch(0);
            Touch dokunma2 = Input.GetTouch(1);

            // Zoom
            if (dokunma1.phase == TouchPhase.Moved && dokunma2.phase == TouchPhase.Moved)
            {
                float dokunmaUzakligi = Vector2.Distance(dokunma1.position, dokunma2.position);
                float oncekiDokunmaUzakligi = Vector2.Distance(dokunma1.position - dokunma1.deltaPosition, dokunma2.position - dokunma2.deltaPosition);
                float fark = (dokunmaUzakligi - oncekiDokunmaUzakligi) * zoomSenstive;
                zoomValue = Mathf.Clamp(zoomValue - fark, minZoom, maxZoom);
                transform.localScale = new Vector3(zoomValue, zoomValue, zoomValue);
            }
        }
    }
}
