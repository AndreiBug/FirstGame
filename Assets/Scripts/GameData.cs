using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public int ammoAmount;
    public int currentWaveNumber;
    public List<EnemyData> remainingEnemies;
}
