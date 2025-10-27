using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceConfig", menuName = "Configs/DiceConfig")]
public class DiceConfig : ScriptableObject
{
    public DiceActor DicePrefab;
    public List<Sprite> DiceSprites;
    public Sprite ChipOne;
    public Sprite ChipTwo;
}
