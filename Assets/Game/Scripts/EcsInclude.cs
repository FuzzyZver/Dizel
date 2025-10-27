using UnityEngine;
using Leopotam.Ecs;

public class EcsInclude : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private UI _ui;
    [SerializeField] private SceneData _sceneData;
    private EcsWorld _world;
    private EcsSystems _systems;
    private RuntimeData _runtimeData = new RuntimeData
    {
        PlayerTurnId = 0,
        FirstPlayerTotalScore = 0,
        SecondPlayerTotalScore = 0,
        FirstPlayerColumnValue = new PLayerColumnValue(),
        SecondPlayerColumnValue = new PLayerColumnValue()
    };


    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems
            //.Add(new ...
            .Add(new InitSystem())
            .Add(new DiceMovableSystem())
            .Add(new MagneticSlotSystem())
            .Add(new RollDiceSystem())
            .Add(new SummingSystem())
            .Add(new EndGameSystem())
            .Add(new ChangeTurnSystem())
            .Add(new CheckValueDiceSystem())

            //OneFrame<...
            .OneFrame<DiceClickEvent>()
            .OneFrame<DropDiceEvent>()
            .OneFrame<RollDiceEvent>()
            .OneFrame<ChangeTurnEvent>()
            .OneFrame<CheckValuesColumnEvent>()

            .Inject(_world)
            .Inject(_gameConfig)
            .Inject(_ui)
            .Inject(_sceneData)
            .Inject(_runtimeData)

            .Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
