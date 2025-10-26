using UnityEngine;
using Leopotam.Ecs;

abstract public class Actor : MonoBehaviour
{
    private EcsWorld _world;
    private EcsEntity _entity;

    public void Init(EcsWorld world)
    {
        _world = world;
        _entity = _world.NewEntity();
        ExpandEntity(_entity);
    }

    abstract public void ExpandEntity(EcsEntity entity);

    public EcsWorld GetWorld() => _world;
    public EcsEntity GetEntity() => _entity;
}
