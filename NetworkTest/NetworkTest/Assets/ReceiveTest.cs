using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ReceiveTest : MonoBehaviour
{
    private UdpClient udpClient;
    private IPAddress iPAddress;
    private int port;
    private IPEndPoint endPoint;

    private void Awake()
    {
        iPAddress = IPAddress.Parse("127.0.0.1");
        port = 10095;
        udpClient = new UdpClient(port);
        endPoint = new IPEndPoint(iPAddress, port);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        byte[] package = udpClient.Receive(ref endPoint);
        string receive = Encoding.BigEndianUnicode.GetString(package);
        Debug.Log("receive " + receive);
    }



}
