using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 2.0f;

    void Update()
    {
        // Döndürme
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up, mouseX * rotateSpeed);
            transform.Rotate(Vector3.left, mouseY * rotateSpeed);
        }

        // Yakınlaştırma/Uzaklaştırma
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed);
    }
}
