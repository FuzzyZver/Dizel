using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

public class SummingSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    public void Init()
    {

    }

    public void Run()
    {
        RuntimeData.FirstPlayerColumnValue.LeftColumnValue =  SummingColumnValue(SceneData.FirstPlayer.LeftSlots);
        UI.FirstPlayerNumbersView.SetLeftColumnValue(RuntimeData.FirstPlayerColumnValue.LeftColumnValue);

        RuntimeData.FirstPlayerColumnValue.CentralColumnValue = SummingColumnValue(SceneData.FirstPlayer.CentralSlots);
        UI.FirstPlayerNumbersView.SetCentralColumnValue(RuntimeData.FirstPlayerColumnValue.CentralColumnValue);

        RuntimeData.FirstPlayerColumnValue.RightColumnValue = SummingColumnValue(SceneData.FirstPlayer.RightSlots);
        UI.FirstPlayerNumbersView.SetRightColumnValue(RuntimeData.FirstPlayerColumnValue.RightColumnValue);
        RuntimeData.FirstPlayerTotalScore = RuntimeData.FirstPlayerColumnValue.LeftColumnValue + RuntimeData.FirstPlayerColumnValue.CentralColumnValue + RuntimeData.FirstPlayerColumnValue.RightColumnValue;


        RuntimeData.SecondPlayerColumnValue.LeftColumnValue = SummingColumnValue(SceneData.SecondPlayer.LeftSlots);
        UI.FirstPlayerNumbersView.SetLeftColumnValue(RuntimeData.SecondPlayerColumnValue.LeftColumnValue);

        RuntimeData.SecondPlayerColumnValue.CentralColumnValue = SummingColumnValue(SceneData.SecondPlayer.CentralSlots);
        UI.SecondPlayerNumbersView.SetCentralColumnValue(RuntimeData.SecondPlayerColumnValue.CentralColumnValue);

        RuntimeData.SecondPlayerColumnValue.RightColumnValue = SummingColumnValue(SceneData.SecondPlayer.RightSlots);
        UI.SecondPlayerNumbersView.SetRightColumnValue(RuntimeData.SecondPlayerColumnValue.RightColumnValue);
        RuntimeData.SecondPlayerTotalScore = RuntimeData.SecondPlayerColumnValue.LeftColumnValue + RuntimeData.SecondPlayerColumnValue.CentralColumnValue + RuntimeData.SecondPlayerColumnValue.RightColumnValue;
    }

    private int SummingColumnValue(List<SlotActor> slotActors)
    {
        List<int> values = new List<int>();

        foreach (SlotActor slot in slotActors)
        {
            if (!slot.GetEntity().Has<MagneticFlag>())
            {
                var diceEntity = slot.GetEntity().Get<SlotStorage>().Entity;
                int diceValue = diceEntity.Get<DiceValue>().Value;
                values.Add(diceValue);
            }
        }

        if (values.Count == 0)
            return 0;

        if (values.Count == 1)
            return values[0];

        int sum = 0;
        foreach (int v in values)
            sum += v;

        bool allEqual = values.TrueForAll(v => v == values[0]);
        if (allEqual)
            return sum * 3;

        for (int i = 0; i < values.Count; i++)
        {
            for (int j = i + 1; j < values.Count; j++)
            {
                if (values[i] == values[j])
                {
                    int doubledPair = (values[i] + values[j]) * 2;
                    int other = 0;
                    for (int k = 0; k < values.Count; k++)
                    {
                        if (k != i && k != j)
                            other += values[k];
                    }
                    return doubledPair + other;
                }
            }
        }

        return sum;
    }

}
