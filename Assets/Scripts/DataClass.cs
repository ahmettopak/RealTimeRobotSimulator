using System;

public class DataClass
{ 
    public static String ROBOT_MAIN_IP = "192.168.3.2";
    public static int UDP_PORT = 10008;
    public static int COMMAND_SIZE = 6;
    public static byte C = (byte)0x43, R = (byte)0x52;

    public static byte TURRET = (byte)0x97;
    public static byte SHOULDER = (byte)0x91;
    public static byte ELBOW = (byte)0x9D;
    public static byte WRIST = (byte)0xB7;
    public static byte CLAMP = (byte)0x77;
    public static byte CLAMP_TURRET = (byte)0x74;
    public static byte FRONTPAL = (byte)0xB1;
    public static byte BACKPAL = (byte)0x8D;

    //EMU
    public static byte MEMS_WRITE = (byte)0x48;
    public static byte MEMS_X_READ = (byte)0x48;
    public static byte MEMS_Y_READ = (byte)0x49;
    public static byte MEMS_Z_READ = (byte)0x4A;
    
}