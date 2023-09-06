using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 2.0f;
    public GameObject model;
    public GameObject camera;


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Döndürme
        if (Input.GetMouseButton(0))
        {

            model.transform.Rotate(Vector3.right, mouseY * rotateSpeed);
        }
        else if (Input.GetMouseButton(1))
        {
            model.transform.Rotate(Vector3.down, mouseX * rotateSpeed);

        }

        // Yakınlaştırma/Uzaklaştırma
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camera.transform.Translate(Vector3.forward * scroll * zoomSpeed);
    }
}
