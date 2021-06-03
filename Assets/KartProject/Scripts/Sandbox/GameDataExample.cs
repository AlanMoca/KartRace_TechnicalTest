using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataExample
{
    public PlayerDataExample player;
    public List<LevelMatchDataExample> levels;
}

public class PlayerDataExample
{
    public string name;
    public CarDataExample car;
}

public class LevelMatchDataExample
{
    public bool unlocked;
    public float bestTime;
    public CoinDataExample coins;
    public int numberOfAttemps;
}

public class CarDataExample
{
    public int wheels;
    public int bodywork;
}

public class CoinDataExample
{
    public int id;
    public bool hasPickedUp;
}

public class PotionDataExample
{
    public int id;
    public int effect;
    public int duration;
    public bool hasPickedUp;
}

public class BoxDataExample
{
    public int id;
    public List<CoinDataExample> coins;
    public List<PotionDataExample> potions;
}
