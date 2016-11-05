using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileController : MonoBehaviour
{

    private static string[] ships;
    private static string[] worlds;
    private static int money;

    private string shipsFile;
    private string worldsFile;
    private string moneyFile;

    void Awake()
    {
        shipsFile = Application.persistentDataPath + "/ships";
        readShipsFile();
        worldsFile = Application.persistentDataPath + "/world";
        readWorldFile();
        moneyFile = Application.persistentDataPath + "/money";
        readMoneyFile();
    }



    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update() { }


    private void readShipsFile()
    {
        try
        {
            if (!File.Exists(shipsFile)) File.WriteAllText(shipsFile, "1,0,0,0,0"); //1 = unlocked, 0 = locked
            ships = File.ReadAllText(shipsFile).Split(',');
        }
        catch (Exception ex) { print("Fail to read ships file " + ex); }
    }

    private void readWorldFile()
    {
        try
        {
            if (!File.Exists(worldsFile)) File.WriteAllText(worldsFile, "1,0,0,0,"); // 1 = easy unlocked, 2 = med unlocked, 3 = hard unlocked, 0 = all locked
            worlds = File.ReadAllText(worldsFile).Split(',');
        }
        catch (Exception ex) { print("Fail to read world file " + ex); }
    }

    private void readMoneyFile()
    {
        try
        {
            if (!File.Exists(moneyFile)) File.WriteAllText(moneyFile, "0");
            money = int.Parse(File.ReadAllText(moneyFile));
        }
        catch (Exception ex) { print("Fail to read money file " + ex); }

    }

    private void storeShips()
    {
        string aux="";
        for (int i = 0; i < ships.Length; i++)
        {
            aux += ships[i] + ",";
        }
        File.WriteAllText(shipsFile, aux);
    }

    private void storeWorlds()
    {
        string aux="";
        for (int i = 0; i < worlds.Length; i++)
        {
            aux += worlds[i] + ",";
        }
        File.WriteAllText(worldsFile, aux);
    }

    private void storeMoney()
    {
        File.WriteAllText(moneyFile, money.ToString());
    }

    public string[] getShips() { return ships; }
    public string[] getWorlds() { return worlds; }

    public int getMoney()
    {
        return money;
    }

    private void unlockShip(int shipNumber)
    {
        ships[shipNumber] = "1";
        storeShips();
    }

    public void increaseMoney(int amount)
    {
        money += amount;
        storeMoney();
    }

    public void purchaseShip(int shipNumber, int amount)
    {
        increaseMoney(-amount);
        unlockShip(shipNumber);
    }

    public void unlockWorld(int world, int difficulty)
    {
        if (int.Parse(worlds[world]) < difficulty) worlds[world] = difficulty + 1 + "";
        if (int.Parse(worlds[world + 1]) == 0) worlds[world + 1] = "1";
        storeWorlds();
    }

}
