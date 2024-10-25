using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void BuildTower(SpawnableTowers tower)
    {
        Debug.Log("I spawn" + tower);
    }
}
