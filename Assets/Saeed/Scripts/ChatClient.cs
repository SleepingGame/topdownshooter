using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ChatClient : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";
    public int port = 1337;
    public InputField messageInputField;
    public Text chatText;

    private TcpClient client;
    private NetworkStream stream;
    private byte[] receiveBuffer = new byte[256];

    private void Start()
    {
        ConnectToServer();
    }

    private void Update()
    {
        if (stream != null && stream.DataAvailable)
        {
            int bytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
            string message = System.Text.Encoding.UTF8.GetString(receiveBuffer, 0, bytesRead);
            chatText.text += message + "\n";
        }
    }

    private void OnDestroy()
    {
        if (client != null)
        {
            client.Close();
        }
    }

    public void SendMessage()
    {
        string message = messageInputField.text;

        if (message != "")
        {
            byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes(message);
            stream.Write(sendBuffer, 0, sendBuffer.Length);
            messageInputField.text = "";
        }
    }

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient(ipAddress, port);
            stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.Log($"Error: {e.Message}");
        }
    }
}