using System.Collections.Generic;
using UnityEngine;

public class RuntimeData
{
    public int PlayerTurnId;
    public int FirstPlayerTotalScore;
    public int SecondPlayerTotalScore;
    public PLayerColumnValue FirstPlayerColumnValue;
    public PLayerColumnValue SecondPlayerColumnValue;
}

[System.Serializable]
public class PLayerColumnValue
{
    public int LeftColumnValue;
    public int CentralColumnValue;
    public int RightColumnValue;
}
