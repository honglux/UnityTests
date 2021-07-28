using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;

public class SendGC : MonoBehaviour
{
#if UNITY_STANDALONE_WIN

    [SerializeField] private TextMesh Stext;
    [SerializeField] private TextMesh Rtext;
    // prefs
    [SerializeField] private string IP;  // define in init
    [SerializeField] private int port;  // define in init
    [SerializeField] private int rec_port;

    [SerializeField] private float SendInterval;

    // "connection" things
    private IPEndPoint remoteEndPoint;
    private UdpClient client;
    private float send_timer;
    private int counter;

    private static IPEndPoint rece_EP;
    private static UdpClient rece_client;
    private Thread receive_thread;
    private bool listening;
    private string rec_message;

    private void Awake()
    {
        send_timer = Time.time + SendInterval;
        counter = 0;
        receive_thread = null;
        listening = false;
        rec_message = "";
    }

    public void Start()
    {
        if (IP != "")
        {
            init();
        }

        
        
    }

    public void Update()
    {
        update_rec_message(rec_message);
    }

    // init
    public void init()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
        rece_EP = new IPEndPoint(IPAddress.Any, rec_port);
        rece_client = new UdpClient(rec_port);

        start_listen();
    }

    // sendData: TODO: Sequence Numbers
    public void SendUDPMessage(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
            update_text(message);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    private void update_text(string message)
    {
        Stext.text = Time.time.ToString() + " " + message;
    }

    private void start_listen()
    {
        listening = true;
        receive_thread = new Thread(listen_threading);
        receive_thread.Start();
    }

    private void listen_threading()
    {
        try
        {
            // read quaternions
            while (listening)
            {
                byte[] receiveBytes = rece_client.Receive(ref rece_EP);
                rec_message = Encoding.UTF8.GetString(receiveBytes);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("read coil terminated");
        }
        finally
        {
            try
            {
                rece_client.Close();
                rece_client = null;
            }
            catch { }
        }
    }

    public void Send_message()
    {
        SendUDPMessage(counter.ToString());
        ++counter;
    }

    private void update_rec_message(string message)
    {
        Rtext.text = message;
    }

    //void OnDisable()
    //{
    //    client.Close();
    //    rece_client.Close();
    //    rece_client = null;

    //    listening = false;
    //    // attempt to join for 500ms
    //    if (!receive_thread.Join(500))
    //    {
    //        // force shutdown
    //        receive_thread.Abort();
    //    }
    //}

    private void OnApplicationQuit()
    {
        try
        {
            client.Close();
            rece_client.Close();
            rece_client = null;
        }
        catch (Exception e) { Debug.Log(e); } 


        listening = false;
        // attempt to join for 500ms
        if (!receive_thread.Join(500))
        {
            // force shutdown
            receive_thread.Abort();
        }
    }

    private void OnDestroy()
    {
        try
        {
            client.Close();
            rece_client.Close();
            rece_client = null;
        }
        catch (Exception e) { Debug.Log(e); }

        listening = false;
        // attempt to join for 500ms
        if (!receive_thread.Join(500))
        {
            // force shutdown
            receive_thread.Abort();
        }
    }
#endif
}
