using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneData : MonoBehaviour
{
    public PlayerData FirstPlayer;
    public PlayerData SecondPlayer;
    public Transform DiceSpawnPoint;
    public SpriteRenderer Chip;
}

[System.Serializable]
public class PlayerData
{
    public string Name;
    public List<SlotActor> LeftSlots;
    public List<SlotActor> CentralSlots;
    public List<SlotActor> RightSlots;
}
