using UnityEngine;
using Leopotam.Ecs;

public class SpawnDiceMono : MonoBehaviour
{
    private EcsWorld _world;

    public void Init(EcsWorld world)
    {
        _world = world;
    }

    public void RollDice()
    {
        _world.NewEntity().Get<RollDiceEvent>();
    }
}
