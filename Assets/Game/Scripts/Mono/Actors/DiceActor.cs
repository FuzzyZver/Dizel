using UnityEngine;
using Leopotam.Ecs;

public class DiceActor: Actor
{
    [SerializeField] private Transform _transform;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    override public void ExpandEntity(EcsEntity entity)
    {
        entity.Get<TransformRef>().Transform = _transform;
        entity.Get<MovableFlag>();
        entity.Get<SpriteRendererRef>().SpriteRenderer = _spriteRenderer;
    }

    private void OnMouseDown()
    {
        GetWorld().NewEntity().Get<DiceClickEvent>().Entity = GetEntity();
    }
}
