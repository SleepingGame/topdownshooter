using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;

public class PlayerPosition : MonoBehaviour
{
    public string ipAddress = "127.0.0.1";
    public int port = 1337;


    public float sendInterval = 0.5f;

    private TcpClient client;

    // Start is called before the first frame update
    void Start()
    {
        client = new TcpClient(ipAddress, port);
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(SendPosition());
    }

    IEnumerator SendPosition()
    {
        yield return new WaitForSeconds(sendInterval);

        Vector3 position = transform.position;
        string positionString = position.x + "," + position.y + "," + position.z;

        NetworkStream stream = client.GetStream();
        byte[] message = System.Text.Encoding.UTF8.GetBytes(positionString);
        stream.Write(message, 0, message.Length);
    }
}