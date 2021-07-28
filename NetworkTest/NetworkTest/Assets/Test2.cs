using UnityEngine;
using System.Collections;

#if UNITY_STANDALONE_WIN
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
#endif

public class UDPSend : MonoBehaviour
{
#if UNITY_STANDALONE_WIN

    // prefs
    [SerializeField]
    public string IP;  // define in init
    [SerializeField]
    public int port;  // define in init

    public GameObject fileName;
    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    public void Start()
    {
        if (IP != "")
        {
            init();
        }
    }

    // init
    public void init()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
    }

    // sendData: TODO: Sequence Numbers
    public void SendUDPMessage(string message)
    {

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
            //Debug.Log("sent" + IP);
            //Debug.Log(message);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    void OnDisable()
    {
        client.Close();
    }
#endif
}