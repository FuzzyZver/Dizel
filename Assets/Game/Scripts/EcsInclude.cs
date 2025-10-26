using UnityEngine;
using Leopotam.Ecs;

public class EcsInclude : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private UI _ui;
    [SerializeField] private SceneData _sceneData;

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

            //OneFrame<...
            .OneFrame<DiceClickEvent>()
            .OneFrame<DropDiceEvent>()
            .OneFrame<RollDiceEvent>()

            .Inject(_world)
            .Inject(_gameConfig)
            .Inject(_ui)
            .Inject(_sceneData)

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
