using UnityEngine;
using Leopotam.Ecs;

public class SlotActor: Actor
{
    [SerializeField] private Transform _transform;

    override public void ExpandEntity(EcsEntity entity)
    {
        entity.Get<TransformRef>().Transform = _transform;
        entity.Get<MagneticFlag>();
        entity.Get<SlotStorage>();
    }
}
