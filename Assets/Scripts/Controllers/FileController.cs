using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileController : MonoBehaviour
{
    private int nShip;
    private int nWorld;
    private string filePath;
    private int earth;
    private int mars;
    private int saturn;
    public Text debugText;
    // Use this for initialization
    void Start ()
	{
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(transform.gameObject);
        filePath = Application.persistentDataPath + "/unlockeables.txt";
        loadUnlockeables();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void loadUnlockeables()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "1,0,0,0,0"); //naves,mundos,tierra en dificil, marte en dificil, saturno en dificil
                nShip = 1;
                nWorld = 0;
            }
            else
            {
                read();
            }
        }catch (Exception e)
        {

        }
        debugText.text = nShip + "," + nWorld + "," + earth + "," + mars + "," + saturn;
    }

    private void read()
    {
        try
        {
            String[] result = File.ReadAllText(filePath).Split(',');
            nShip = Int32.Parse(result[0]);
            nWorld = Int32.Parse(result[1]);
            earth = Int32.Parse(result[2]);
            mars = Int32.Parse(result[3]);
            saturn = Int32.Parse(result[4]);
        }
        catch (Exception e)
        {
            
        }
    }

    public void writeUnlockeables(int ship, int world)
    {
        File.WriteAllText(filePath, ship+","+world+","+earth+","+mars+","+saturn);
        nShip = ship;
        nWorld = world;
    }

    public void writeHardWorldPassed(String world)
    {
        switch (world)
        {
            case "Earth": File.WriteAllText(filePath, nShip + "," + nWorld + "," + 1 + "," + mars + "," + saturn);
                earth = 1;
                break;
            case "Mars": File.WriteAllText(filePath, nShip + "," + nWorld + "," + earth + "," + 1 + "," + saturn);
                mars = 1;
                break;
            case "Saturn": File.WriteAllText(filePath, nShip + "," + nWorld + "," + earth + "," + mars + "," + 1);
                saturn = 1;
                break;
        }
    }

    public int getNShip()
    {
        return nShip;
    }

    public int getNWorld()
    {
        return nWorld;
    }

    public string getLastUnlockedWorldName()
    {
        switch (nWorld)
        {
            case 0:
                return "Earth";
            case 1:
                return "Mars";
            case 2:
                return "Saturn";
        }
        return "none";
    }
    public bool isWorldPassedInHard(String world)
    {
        if (world == "Earth" && earth == 0) return true;
        if (world == "Mars" && mars == 0) return true;
        if (world == "Saturn" && saturn == 0) return true;
        return false;
    }
}
