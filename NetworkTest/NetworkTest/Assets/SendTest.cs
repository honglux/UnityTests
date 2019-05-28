using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class SendTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        send_test();
    }

    public void send_test()
    {
        Debug.Log("sending");
        //byte[] package = Encoding.BigEndianUnicode.GetBytes("{");
        byte[] package = new byte[] { 123 };
        send_udp(IPAddress.Parse("127.0.0.1"), 10095, package);
    }

    private void send_udp(IPAddress iPAddress, int port, byte[] package)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                                    ProtocolType.Udp);
        IPEndPoint endPoint = new IPEndPoint(iPAddress, port);
        socket.SendTo(package, endPoint);
        socket.Close();
    }
}
