using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using System;
using UnityEngine.XR;

public class WebSocketRobotControl : MonoBehaviour
{

    WebSocket websocket;
    private const string turretModelId = "1";
    private const string shoulderModelId = "2";
    private const string elbowModelId = "3";
    private const string wristModelId = "4";
    private const string clampModelId = "5";
    private const string clampTurretModelId = "6";
    private const string frontPalModelId = "7";
    private const string backPaltModelId = "8";

    public GameObject turret;
    public GameObject shoulder;
    public GameObject elbow;
    public GameObject wrist;
    public GameObject clampTurret;
    public GameObject clampBottom;
    public GameObject clampTop;
    public GameObject frontPal;
    public GameObject frontPal2;
    public GameObject backPal;
    public GameObject backPal2;

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

        websocket.OnError +=  (e) =>
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
                case turretModelId:
                    turret.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case shoulderModelId:
                    shoulder.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case elbowModelId:
                    elbow.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case wristModelId:
                    wrist.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case clampModelId:
                    clampTop.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    clampBottom.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case clampTurretModelId:
                    clampTurret.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case backPaltModelId:
                    backPal.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    backPal2.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));

                    break;
                case frontPalModelId:
                    frontPal.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    frontPal2.transform.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));

                    break;

                default:
                    break;
            }

        
                switch (GetArmSelectId(message))
                {
                    case turretModelId:
                        if (GetSelectedValue(message))
                        {
                            turret.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            turret.GetComponent<Renderer>().material.color = Color.black;

                        }
                        break;
                    case shoulderModelId:
                        if (GetSelectedValue(message))
                        {
                            shoulder.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            shoulder.GetComponent<Renderer>().material.color = defaultArmColor;

                        }
                        break;
                    case elbowModelId:
                        if (GetSelectedValue(message))
                        {
                            elbow.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            elbow.GetComponent<Renderer>().material.color = defaultArmColor;

                        }
                        break;
                    case wristModelId:
                        if (GetSelectedValue(message))
                        {
                            wrist.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            wrist.GetComponent<Renderer>().material.color = Color.black;

                        }
                        break;
                    case clampModelId:
                        if (GetSelectedValue(message))
                        {
                            clampBottom.GetComponent<Renderer>().material.color = selectedColor;
                            clampTop.GetComponent<Renderer>().material.color = selectedColor;
                            clampTurret.GetComponent<Renderer>().material.color = selectedColor;


                        }
                        else
                        {
                            clampBottom.GetComponent<Renderer>().material.color = Color.black;
                            clampTop.GetComponent<Renderer>().material.color = Color.black;
                            clampTurret.GetComponent<Renderer>().material.color = Color.black;

                        }
                        break;

                    case backPaltModelId:
                        if (GetSelectedValue(message))
                        {
                            backPal.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            backPal.GetComponent<Renderer>().material.color = Color.black;

                        }
                        break;
                    case frontPalModelId:
                        if (GetSelectedValue(message))
                        {
                            frontPal.GetComponent<Renderer>().material.color = selectedColor;
                        }
                        else
                        {
                            frontPal.GetComponent<Renderer>().material.color = Color.black;

                        }
                        break;

                    default:
                        break;
                }
            
            //Debug.Log(GetSelectedValue(message));

        };


        // waiting for messages
        Debug.Log("Bağlanmaya Başlanıyor.");
        await websocket.Connect();

    }

    // Update is called once per frame
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
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
        return message.Substring(0,1);
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
