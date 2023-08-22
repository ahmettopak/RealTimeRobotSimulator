using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;
using System;

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

    public Transform turret;
    public Transform shoulder;
    public Transform elbow;
    public Transform wrist;
    public Transform clampTurret;
    public Transform clampBottom;
    public Transform clampTop;
    public Transform frontPal;
    public Transform backPal;
    async void Start()
    {
        websocket = new WebSocket("ws://localhost:2005");
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
                case turretModelId:
                    turret.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case shoulderModelId:
                    shoulder.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case elbowModelId:
                    elbow.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case wristModelId:
                    wrist.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case clampModelId:
                    clampTop.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    clampBottom.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case clampTurretModelId:
                    clampTurret.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case backPaltModelId:
                    backPal.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;
                case frontPalModelId:
                    frontPal.localRotation = Quaternion.Euler(0f, 0f, GetValue(message));
                    break;

                default:
                    break;
            }
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

    private int GetValue(string message)
    {
        return Convert.ToUInt16(message.Substring(1));
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}
