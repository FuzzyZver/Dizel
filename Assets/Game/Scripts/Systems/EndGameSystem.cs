using UnityEngine;
using Leopotam.Ecs;

public class EndGameSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<MagneticFlag> _magneticFlagFilter;
    private bool _isGameEnd = false;

    public void Init()
    {

    }

    public void Run()
    {
        if(_magneticFlagFilter.GetEntitiesCount() == 0 && !_isGameEnd)
        {
            EndGameScreen endGameScreen = GameObject.Instantiate(GameConfig.CommonConfig.EndGameScreen, UI.ScreensSpawn);
            endGameScreen.SetScore(Mathf.Max(RuntimeData.FirstPlayerTotalScore, RuntimeData.SecondPlayerTotalScore));
            _isGameEnd = true;
        }
    }
}
