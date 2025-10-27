using UnityEngine;
using Leopotam.Ecs;

public class ChangeTurnSystem: Injects, IEcsRunSystem
{
    private EcsFilter<ChangeTurnEvent> _changeTurnEventFilter;

    public void Run()
    {
        foreach(int i in _changeTurnEventFilter)
        {
            if(RuntimeData.PlayerTurnId == 0)
            {
                SceneData.Chip.sprite = GameConfig.DiceConfig.ChipTwo;
                RuntimeData.PlayerTurnId = 1;
            }
            else if(RuntimeData.PlayerTurnId == 1)
            {
                SceneData.Chip.sprite = GameConfig.DiceConfig.ChipOne;
                RuntimeData.PlayerTurnId = 0;
            }
        }
    }
}
