using System.Collections.Generic;
using UnityEngine;
public class SpawnerObjectPool
{
    private Dictionary <string, SpawnerObject> spawnerPool;

    public SpawnerObjectPool()
    {
        spawnerPool = new Dictionary<string, SpawnerObject>();
        spawnerPool.Add("Meteorite", new SpawnerObject(Resources.Load("Prefabs/Meteorite") as GameObject,3,3));
    }

}