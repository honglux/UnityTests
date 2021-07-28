using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class TCPSenderGC : MonoBehaviour
{
    [SerializeField] private TextMesh sender_text;
    [SerializeField] private int endport;
    [SerializeField] private string endIP;

    private static IPAddress end_ipaddress;
    private static IPEndPoint end_EP;
    private static TcpClient tcp_client;
    private static NetworkStream net_stream;

    private int counter;

    private void Awake()
    {
        counter = 0;

        end_ipaddress = IPAddress.Parse(endIP);
        end_EP = new IPEndPoint(end_ipaddress, endport);

        tcp_client = null;
        net_stream = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void connect_TCP()
    {
        tcp_client = new TcpClient();
        tcp_client.Connect(end_EP);
        sender_text.text = "Connected!";
    }

    private void write_TCP(string message)
    {
        if (net_stream == null) { net_stream = tcp_client.GetStream(); }
        byte[] data = Encoding.UTF8.GetBytes(message);
        net_stream.Write(data, 0, data.Length);
        sender_text.text = "Write " + message;

        Byte[] bytes = new Byte[256];

        int i;
        bool received = false;
        string rec_message = "";
        // Loop to receive all the data sent by the client.
        while (!received && (i = net_stream.Read(bytes, 0, bytes.Length)) != 0)
        {
            rec_message = Encoding.UTF8.GetString(bytes, 0, i);
            sender_text.text = "Received " + rec_message;
            received = true;
        }
    }

    public void ConnectTCP()
    {
        connect_TCP();
    }

    public void WriteTCP()
    {
        write_TCP(counter.ToString());
        ++counter;
    }

    private void OnDestroy()
    {
        net_stream.Close();
        tcp_client.Close();
    }

    private void OnApplicationQuit()
    {
        net_stream.Close();
        tcp_client.Close();
    }
}
