using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileController : MonoBehaviour
{

    private static ship[] ships;
    private static string[] worlds;
    private static int money;

    private string shipsFile;
    private string worldsFile;
    private string moneyFile;

    private int numberOfShips;

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
        purchaseShip(0, 2, 0);
    }

    // Update is called once per frame
    void Update() { }


    private void readShipsFile()
    {
        try
        {
            if (!File.Exists(shipsFile)) File.WriteAllText(shipsFile, "1,0,0,0.1,0,0,0.1,0,0,0.1,0,0,0"); //1 = unlocked, 0 = locked
            numberOfShips = File.ReadAllText(shipsFile).Split('.').Length;
            ships = new ship[numberOfShips];
            for (int i = 0; i < numberOfShips; i++)
            {
                ships[i] = new ship(File.ReadAllText(shipsFile).Split('.')[i].Split(','));
            }
        }
        catch (Exception ex) { print("Fail to read ships file " + ex); }
    }

    private void readWorldFile()
    {
        try
        {
            if (!File.Exists(worldsFile)) File.WriteAllText(worldsFile, "1,0,0,"); // 1 = easy unlocked, 2 = med unlocked, 3 = hard unlocked, 0 = all locked
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
        string aux = "";
        for (int i = 0; i < numberOfShips; i++)
        {
            for (int j = 0; j < ships[i].color.Length; j++)
            {
                aux += ships[i].color[j];
                if (j < ships[i].color.Length-1 ) aux += ",";
            }
            if(i < numberOfShips-1) aux += ".";
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

    //TO DO check if this function is needed, if not delete it. (I'm not sure if we comment in english or spanish :D )
    public string[] getShipColors(int ship)
    {
        return ships[ship].color;//except
    }

    public int getShipCount()
    {
        return ships.Length;
    }

    public string[] getWorlds() { return worlds; }

    public bool isUnlocked(int ship, int color)
    {
        return ships[ship].color[color].Equals("1") ? true : false;
    }

    public int getMoney()
    {
        return money;
    }

    private void unlockShip(int shipNumber, int color)
    {
        ships[shipNumber].unlock(color);
        storeShips();
    }

    public void increaseMoney(int amount)
    {
        money += amount;
        storeMoney();
    }

    public void purchaseShip(int shipNumber, int color, int price)
    {
        increaseMoney(-price);
        unlockShip(shipNumber, color);
    }

    public void unlockWorld(int world, int difficulty)
    {
        if (int.Parse(worlds[world]) < difficulty) worlds[world] = difficulty + 1 + "";
        if (int.Parse(worlds[world + 1]) == 0) worlds[world + 1] = "1";
        storeWorlds();
    }

    private class ship
    {
        private string[] _color;

        public ship(string[] color)
        {
            _color = color;
        }

        public string[] color
        {
            get { return _color; }
            set { _color = value; }
        }

        public void unlock(int color)
        {
            _color[color] = "1";
        }
    }

}
