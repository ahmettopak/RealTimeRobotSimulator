using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class UdpRobotController : MonoBehaviour
{
    public Transform turret;
    public Transform shoulder;
    public Transform elbow;
    public Transform wrist;
    public Transform clampTurret;
    public Transform clampBottom;
    public Transform clampTop;
    public Transform frontPal;
    public Transform backPal;

    UdpClient udpClient;


    void Start()
    {
        udpClient = new UdpClient(DataClass.UDP_PORT);
        StartListening();
    }

    private void OnApplicationQuit()
    {
       // udpClient.Dispose();
    }


    public async void StartListening()
    {
     
        try
        {
      
           while (true) {
                Debug.Log("Veri bekleniyor...");
                UdpReceiveResult result = await udpClient.ReceiveAsync();

                byte[] data = result.Buffer;
                
                if (data.Length == 6)
                {

                    String[] hexData = UdpUtils.ByteArrayToHexArray(data);
                    if (UdpUtils.ValidateReceivePacket(data))
                    {
                        byte id = data[2];
                        byte d0 = data[3];
                        byte d1 = data[4];
                        string fullValue = hexData[3] + hexData[4];

                        if (id == DataClass.TURRET)
                        {
                            turret.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.SHOULDER)
                        {
                            shoulder.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.ELBOW)
                        {
                            elbow.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.WRIST)
                        {
                            wrist.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.CLAMP)
                        {
                            clampBottom.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                            clampTop.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.CLAMP_TURRET)
                        {
                            clampTurret.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.FRONTPAL)
                        {
                            frontPal.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }
                        else if (id == DataClass.BACKPAL)
                        {
                            backPal.localRotation = Quaternion.Euler(0f, 0f, UdpUtils.ToInt(fullValue));
                        }


                        string message = $"ID: {id}, Variable: {d0}, Variable2: {d1}";


                        Debug.Log(message);
                    }



                }
           }
            
        }
        catch (Exception ex)
        {
          Debug.LogException(ex);
        }
    }
}
