using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Text;
using System.IO;

public class ReceiveGC : MonoBehaviour
{
    [SerializeField] private int Port;
    [SerializeField] private int from_port;
    [SerializeField] private float ReceiveInterval;
    [SerializeField] private string file_path;

    private bool listening;
    private static UdpClient udpClient;
    private static IPEndPoint EP;
    private static UdpClient send_udpClient;
    private static IPEndPoint send_EP;
    private static IPAddress from_IPadd;
    private Thread receive_thread;
    protected string message;

    private void Awake()
    {
        listening = false;
        message = "";

        try
        {
            udpClient = new UdpClient(Port);
            EP = new IPEndPoint(IPAddress.IPv6Any, Port);
            send_udpClient = new UdpClient();
            send_EP = null;
            from_IPadd = IPAddress.IPv6Any;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        start_RP_thread();
    }

    private void receiving()
    {
        try
        {
            // read quaternions
            while (listening)
            {
                byte[] receiveBytes = udpClient.Receive(ref EP);
                //message = Encoding.UTF8.GetString(receiveBytes);
                message = Encoding.UTF8.GetString(receiveBytes) + "__" + EP.Address.ToString();
                Debug.LogError(message);
                update_file(message);
                try
                {
                    send_back_message("Hello, " + message + "_" + EP.Address.ToString(), EP);
                }
                catch (Exception e) { Debug.LogError(e); }
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
                udpClient.Close();
                udpClient = null;
                send_udpClient.Close();
                send_udpClient = null;
            }
            catch { }
        }
    }

    private void start_RP_thread()
    {
        listening = true;
        receive_thread = new Thread(receiving);
        receive_thread.Start();
    }

    private void update_message(string message)
    {
        update_file(message);
    }

    private void update_file(string message)
    {
        StreamWriter file;
        if (!File.Exists(file_path))
        {
            file = new StreamWriter(file_path);
        }
        else
        {
            file = File.AppendText(file_path);
        }
        file.WriteLine(message);
        file.Close();
    }

    private void send_back_message(string message, IPEndPoint from_EP)
    {
        try
        {
            from_IPadd = from_EP.Address;
            send_EP = new IPEndPoint(from_IPadd, from_port);

            byte[] data = Encoding.UTF8.GetBytes(message);
            send_udpClient.Send(data, data.Length, send_EP);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    private void OnApplicationQuit()
    {
        try
        {
            // signal shutdown
            listening = false;

            // attempt to join for 500ms
            if (!receive_thread.Join(500))
            {
                // force shutdown
                receive_thread.Abort();
                if (udpClient != null)
                {
                    udpClient.Close();
                    udpClient = null;
                    send_udpClient.Close();
                    send_udpClient = null;
                }
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
            // signal shutdown
            listening = false;

            // attempt to join for 500ms
            if (!receive_thread.Join(500))
            {
                // force shutdown
                receive_thread.Abort();
                if (udpClient != null)
                {
                    udpClient.Close();
                    udpClient = null;
                    send_udpClient.Close();
                    send_udpClient = null;
                }
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
