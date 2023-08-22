using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdpUtils : MonoBehaviour
{
   
        public byte[] GenerateUdpData(byte id, byte d0, byte d1)
        {

            byte[] udpData = new byte[6];
            udpData[0] = DataClass.C;
            udpData[1] = DataClass.R;
            udpData[2] = id;
            udpData[3] = d0;
            udpData[4] = d1;
            udpData[5] = GenerateChecksum(id, d0, d1);

            return udpData;
        }

        public static bool ValidateChecksum(byte id, byte d0, byte d1, byte checksum)
        {

            byte cs = (byte)((id + d0 + d1) % 256);
            if (cs == checksum)
            {
                return true;
            }
            return false;
        }

        public static bool ValidateReceivePacket(byte[] data)
        {

            if (data[0] == DataClass.R && data[1] == DataClass.C && ValidateChecksum(data[2], data[3], data[4], data[5]))
            {
                return true;
            }

            return false;
        }

        public static byte GenerateChecksum(byte id, byte d0, byte d1)
        {
            return (byte)((id + d0 + d1) % 256);
        }


        public static string ToHex(byte value)
        {
            return value.ToString("X2");
        }

        public static string ToHex(int value)
        {
            return value.ToString("X2");
        }
        public static int ToInt(byte value)
        {
            return Convert.ToInt32(value);
        }

        public static int ToInt(string value)
        {
            return int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        }

        public static string[] ByteArrayToHexArray(byte[] byteArray)
        {
            string[] hexArray = new string[byteArray.Length];

            for (int i = 0; i < byteArray.Length; i++)
            {
                hexArray[i] = byteArray[i].ToString("X2");
            }

            return hexArray;
        }
    
}
