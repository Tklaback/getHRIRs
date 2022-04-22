using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class socketClient : MonoBehaviour
{
    static TcpListener listener = new TcpListener(IPAddress.Any, 65432);
    static TcpClient c;
    static NetworkStream n;
    void Start()
    {
        listener.Start();
        c = listener.AcceptTcpClient();
        n = c.GetStream();
        //if (c.Connected)
        //{
        //    ExecuteServer();
        //}
    }

    void Update()
    {
       
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Vector3 vec = this.transform.position;

            byte[] msg = Encoding.ASCII.GetBytes(vec.ToString());
            n.Write(msg, 0, msg.Length);
        }

    }

    //public static void StartServer()
    //{
    //    IPHostEntry host = Dns.GetHostEntry("localhost");
    //    IPAddress ipAddress = host.AddressList[0];
    //    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
    //    try
    //    {
    //        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    //        listener.Bind(localEndPoint);
    //        listener.Listen(10);
    //        Debug.Log("Waiting for a connection...");
    //        Socket handler = listener.Accept();
    //        byte[] msg = Encoding.ASCII.GetBytes("HELLO");
    //        handler.Send(msg);
    //        handler.Shutdown(SocketShutdown.Both);
    //        handler.Close();
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.Log("UH OH");
    //    }
    //}
    //public static void ExecuteServer()
    //{



    //    while (true)
    //    {
    //        if (OVRInput.GetDown(OVRInput.Button.One))
    //        {
    //            GameObject controller = GameObject.Find("RightHandAnchor");
    //            Vector3 pos = controller.transform.position;
    //            byte[] msg = Encoding.ASCII.GetBytes(pos.ToString());
    //            n.Write(msg, 0, msg.Length);
    //        }





    //    }
    //    n.Close();
    //}
}



