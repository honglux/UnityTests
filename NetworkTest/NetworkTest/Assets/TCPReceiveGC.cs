using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class TCPReceiveGC : MonoBehaviour
{
    [SerializeField] private TextMesh rec_text;
    [SerializeField] private int listen_port;

    private static TcpListener tcp_listener;


    private Thread receive_thread;
    private bool listening;
    Byte[] bytes;
    string data;

    private void Awake()
    {
        receive_thread = null;
        listening = false;
        bytes = new Byte[0];
        data = "";

        tcp_listener = new TcpListener(IPAddress.Any, listen_port);
    }

    // Start is called before the first frame update
    void Start()
    {
        start_receive();
    }

    // Update is called once per frame
    void Update()
    {
        update_text(data);
    }

    private void start_receive()
    {
        listening = true;
        receive_thread = new Thread(receive_threading);
        receive_thread.Start();
    }

    private void receive_threading()
    {
        try
        {
            tcp_listener.Start();
            while (listening)
            {
                TcpClient client = tcp_listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                bytes = new Byte[256];
                
                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = Encoding.UTF8.GetString(bytes, 0, i);
                    Debug.LogError(data);

                    byte[] out_msg = Encoding.UTF8.GetBytes(data + "ServerBack");

                    // Send back a response.
                    stream.Write(out_msg, 0, out_msg.Length);
                    Debug.LogError("Send "+data);
                }

                client.Close();
            }
        }
        catch (Exception e) { Debug.Log(e); }
    }

    private void update_text(string message)
    {
        rec_text.text = message;
    }

    private void OnApplicationQuit()
    {
        try
        {
            tcp_listener.Stop();

            listening = false;
            if (!receive_thread.Join(500))
            {
                receive_thread.Abort();
            }
            Debug.Log("Thread closed");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("unable to close the connection thread upon application exit. This is not a critical exception.");
        }
    }

    private void OnDestroy()
    {
        try
        {
            tcp_listener.Stop();

            listening = false;
            if (!receive_thread.Join(500))
            {
                receive_thread.Abort();
            }
            Debug.Log("Thread closed");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("unable to close the connection thread upon application exit. This is not a critical exception.");
        }
    }
}
