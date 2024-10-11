using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class PokingManager : MonoBehaviour
{
    private Transform handIndexTipTransform;
    public OVRSkeleton skeleton;
    private GameObject lastPokedCube = null;

    // ESP1 Connection Variables
    bool socketReadyESP1 = false;
    TcpClient mySocketESP1;
    public NetworkStream theStreamESP1;
    StreamWriter theWriterESP1;
    StreamReader theReaderESP1;
    public String HostESP1 = "192.168.0.101"; // Replace with ESP1's IP
    public Int32 PortESP1 = 8080; // Replace with ESP1's Port

    // ESP2 Connection Variables
    bool socketReadyESP2 = false;
    TcpClient mySocketESP2;
    public NetworkStream theStreamESP2;
    StreamWriter theWriterESP2;
    StreamReader theReaderESP2;
    public String HostESP2 = "192.168.0.102"; // Replace with ESP2's IP
    public Int32 PortESP2 = 8080; // Replace with ESP2's Port

    // Mapping cubes to ESPs
    private Dictionary<int, string> myDictionary;
    private Dictionary<int, string> cubeToESPMap;

    void Start()
    {
        // Initialization code here, if needed
        Debug.Log("PokingManager initialized.");

        // Initialize the dictionary for sending data
        myDictionary = new Dictionary<int, string>
        {
            { 1, "1,1\n" },
            { 2, "1,2\n" },
            { 3, "2,1\n" },
            { 4, "2,2\n" },
            { 5, "3,1\n" },
            { 6, "3,2\n" },
            { 7, "4,1\n" },
            { 8, "4,2\n" }
        };

        // Initialize the cube to ESP mapping
        cubeToESPMap = new Dictionary<int, string>
        {
            { 1, "ESP1" },
            { 2, "ESP1" },
            { 3, "ESP1" },
            { 4, "ESP1" },
            { 5, "ESP2" },
            { 6, "ESP2" },
            { 7, "ESP2" },
            { 8, "ESP2" }
        };

        // Setup ESP1 Connection
        try
        {
            mySocketESP1 = new TcpClient(HostESP1, PortESP1);
            theStreamESP1 = mySocketESP1.GetStream();
            theWriterESP1 = new StreamWriter(theStreamESP1);
            theReaderESP1 = new StreamReader(theStreamESP1);
            socketReadyESP1 = true; // ESP1 is connected
            Debug.Log("ESP1 Socket set up");

            Byte[] sendBytesESP1 = Encoding.UTF8.GetBytes("This is the client\n"); // Initial message to ESP1
            theStreamESP1.Write(sendBytesESP1, 0, sendBytesESP1.Length); // Send initial message to ESP1
        }
        catch (SocketException e)
        {
            Debug.LogError("ESP1 Socket error: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError("ESP1 Error: " + e.Message);
        }

        // Setup ESP2 Connection
        try
        {
            mySocketESP2 = new TcpClient(HostESP2, PortESP2);
            theStreamESP2 = mySocketESP2.GetStream();
            theWriterESP2 = new StreamWriter(theStreamESP2);
            theReaderESP2 = new StreamReader(theStreamESP2);
            socketReadyESP2 = true; // ESP2 is connected
            Debug.Log("ESP2 Socket set up");

            Byte[] sendBytesESP2 = Encoding.UTF8.GetBytes("This is the client\n"); // Initial message to ESP2
            theStreamESP2.Write(sendBytesESP2, 0, sendBytesESP2.Length); // Send initial message to ESP2
        }
        catch (SocketException e)
        {
            Debug.LogError("ESP2 Socket error: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError("ESP2 Error: " + e.Message);
        }
    }

    bool IsPoking()
    {
        // Find the index tip transform
        foreach (var b in skeleton.Bones)
        {
            if (b.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                handIndexTipTransform = b.Transform;
                break;
            }
        }

        // Check if the index tip transform was found
        if (handIndexTipTransform != null)
        {
            Debug.Log("Hand index tip transform found.");

            // Get all cubes in the scene, assuming they are tagged "PokeableCube"
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("PokeableCube");

            // Iterate through each cube to check the distance
            foreach (var cube in cubes)
            {
                float distance = Vector3.Distance(handIndexTipTransform.position, cube.transform.position);
                Debug.Log($"Checking distance to cube {cube.name}: {distance}");
                if (distance < 0.05f) // Adjust the distance threshold as needed
                {
                    Debug.Log($"Poking cube {cube.name}");

                    // Parse the cube's name to get a valid key for the dictionary
                    if (int.TryParse(cube.name[cube.name.Length - 1].ToString(), out int cubeKey) && myDictionary.ContainsKey(cubeKey))
                    {
                        // If a new cube is being poked, update the color
                        if (lastPokedCube != cube)
                        {
                            if (lastPokedCube != null)
                            {
                                Debug.Log($"Resetting color of last poked cube {lastPokedCube.name}");
                                lastPokedCube.GetComponent<CubeScript>().ResetColor();
                            }
                            lastPokedCube = cube;
                            lastPokedCube.GetComponent<CubeScript>().SetColor(Color.red);
                        }

                        // Determine which ESP to send data to based on cubeKey
                        string targetESP = cubeToESPMap[cubeKey];

                        if (targetESP == "ESP1" && socketReadyESP1)
                        {
                            try
                            {
                                Byte[] sendBytes = Encoding.UTF8.GetBytes("1\n"); // Sending "1" to ESP1
                                theStreamESP1.Write(sendBytes, 0, sendBytes.Length);
                                Debug.Log($"Sent '1' to ESP1 for cube {cube.name}");
                            }
                            catch (Exception e)
                            {
                                Debug.LogError("Error sending data to ESP1: " + e.Message);
                            }
                        }
                        else if (targetESP == "ESP2" && socketReadyESP2)
                        {
                            try
                            {
                                Byte[] sendBytes = Encoding.UTF8.GetBytes("1\n"); // Sending "1" to ESP2
                                theStreamESP2.Write(sendBytes, 0, sendBytes.Length);
                                Debug.Log($"Sent '1' to ESP2 for cube {cube.name}");
                            }
                            catch (Exception e)
                            {
                                Debug.LogError("Error sending data to ESP2: " + e.Message);
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"Target ESP '{targetESP}' for cube {cube.name} is not connected.");
                        }

                        return true;
                    }
                    else
                    {
                        Debug.LogWarning($"Cube name '{cube.name}' is not a valid key for the dictionary.");
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Hand index tip transform not found.");
        }

        // If no cube is being poked, reset the color of the last poked cube
        if (lastPokedCube != null)
        {
            Debug.Log($"Resetting color of last poked cube {lastPokedCube.name}");
            lastPokedCube.GetComponent<CubeScript>().ResetColor();
            lastPokedCube = null;
        }

        return false;
    }

    void Update()
    {
        // Check for poking in every frame
        IsPoking();
    }

    void OnApplicationQuit()
    {
        // Disconnect ESP1 gracefully
        if (socketReadyESP1)
        {
            try
            {
                theWriterESP1.Close();
                theReaderESP1.Close();
                mySocketESP1.Close();
                Debug.Log("ESP1 Socket closed.");
            }
            catch (Exception e)
            {
                Debug.LogError("Error closing ESP1 connection: " + e.Message);
            }
        }

        // Disconnect ESP2 gracefully
        if (socketReadyESP2)
        {
            try
            {
                theWriterESP2.Close();
                theReaderESP2.Close();
                mySocketESP2.Close();
                Debug.Log("ESP2 Socket closed.");
            }
            catch (Exception e)
            {
                Debug.LogError("Error closing ESP2 connection: " + e.Message);
            }
        }
    }
}