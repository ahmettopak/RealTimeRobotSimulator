using NativeWebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketBogacController : MonoBehaviour
{

    WebSocket websocket;

    private const string driveModelId = "1";
    private const string mastModelId = "2";
    private const string ptzModelId = "3";
    private const string strecherModelId = "4";

    public GameObject leftWhell1;
    public GameObject leftWhell2;
    public GameObject leftWhell3;
    public GameObject rightWhell1;
    public GameObject rightWhell2;
    public GameObject rightWhell3;
    public GameObject ptz;
    public GameObject mast;
    public GameObject strecher;

    private Color defaultArmColor;
    private Color selectedColor;

    public Material defaultArmMaterial;
    public Material selectedArmMaterial;


    async void Start()
    {
        defaultArmColor = defaultArmMaterial.color;
        selectedColor = selectedArmMaterial.color;

        websocket = new WebSocket("ws://192.168.1.19:2005");
        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);


        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");

        };

        websocket.OnMessage += (bytes) =>
        {
            //Debug.Log("OnMessage!");
            // Debug.Log(bytes);

            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            // Debug.Log("OnMessage! " + message);

            switch (GetId(message))
            {
                case driveModelId:
                    break;
                case mastModelId:
                    break;
                case ptzModelId:
                    break;
                case strecherModelId:
                    break;
          

                default:
                    break;

              

            }


            //switch (GetArmSelectId(message))
            //{
            //    case turretModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            turret.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            turret.GetComponent<Renderer>().material.color = Color.black;

            //        }
            //        break;
            //    case shoulderModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            shoulder.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            shoulder.GetComponent<Renderer>().material.color = defaultArmColor;

            //        }
            //        break;
            //    case elbowModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            elbow.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            elbow.GetComponent<Renderer>().material.color = defaultArmColor;

            //        }
            //        break;
            //    case wristModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            wrist.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            wrist.GetComponent<Renderer>().material.color = Color.black;

            //        }
            //        break;
            //    case clampModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            clampBottom.GetComponent<Renderer>().material.color = selectedColor;
            //            clampTop.GetComponent<Renderer>().material.color = selectedColor;
            //            clampTurret.GetComponent<Renderer>().material.color = selectedColor;


            //        }
            //        else
            //        {
            //            clampBottom.GetComponent<Renderer>().material.color = Color.black;
            //            clampTop.GetComponent<Renderer>().material.color = Color.black;
            //            clampTurret.GetComponent<Renderer>().material.color = Color.black;

            //        }
            //        break;

            //    case backPaltModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            backPal.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            backPal.GetComponent<Renderer>().material.color = Color.black;

            //        }
            //        break;
            //    case frontPalModelId:
            //        if (GetSelectedValue(message))
            //        {
            //            frontPal.GetComponent<Renderer>().material.color = selectedColor;
            //        }
            //        else
            //        {
            //            frontPal.GetComponent<Renderer>().material.color = Color.black;

            //        }
            //        break;

            //    default:
            //        break;
            //}

            //Debug.Log(GetSelectedValue(message));

        };


        // waiting for messages
        Debug.Log("Bağlanmaya Başlanıyor.");
        await websocket.Connect();

    }

    public Transform rotationCenter; // Dönme merkezi olarak kullanılacak boş nesne
    public float rotationSpeed = 50f; // Dönme hızı

    [Obsolete]
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
        float horizontalInput = Input.GetAxis("Horizontal"); // Sağa sola dönme inputu al

        leftWhell1.transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);


    }

    private void moveObject(GameObject gameObject, int destinationPose)
    {
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, destinationPose);
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText("plain text message");
        }
    }
    private string GetId(string message)
    {
        return message.Substring(0, 1);
    }
    private string GetArmSelectId(string message)
    {

        if (message.Length > 5)
        {
            return message.Substring(3, 1);

        }
        else
        {
            return message;
        }

    }

    private int GetValue(string message)
    {
        return Convert.ToInt32(message.Substring(1));
    }

    private bool GetSelectedValue(string message)
    {
        if (message.Substring(4) == "True" || message.Substring(4) == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}
