using UnityEngine;
using Leopotam.Ecs;

public class MagneticSlotSystem: Injects, IEcsRunSystem
{
    private EcsFilter<MagneticFlag> _magneticFlagFilter;
    private EcsFilter<DropDiceEvent> _dropDiceEventFilter;
    private float _magneticForce = 2;

    public void Run()
    {
        foreach(int i in _dropDiceEventFilter)
        {
            var dice = _dropDiceEventFilter.Get1(i).Entity;

            foreach(int j in _magneticFlagFilter)
            {
                Transform slotTransform = _magneticFlagFilter.GetEntity(j).Get<TransformRef>().Transform;
                float magneticDistance = slotTransform.localScale.x * _magneticForce;
                Vector3 distance = dice.Get<TransformRef>().Transform.position - slotTransform.position;
                if (distance.magnitude <= magneticDistance )
                {
                    dice.Get<TransformRef>().Transform.position = slotTransform.position;
                    dice.Del<MovableFlag>();

                    _magneticFlagFilter.GetEntity(j).Get<SlotStorage>().Entity = dice;
                    _magneticFlagFilter.GetEntity(j).Del<MagneticFlag>();
                }
            }
        }
    }
}
