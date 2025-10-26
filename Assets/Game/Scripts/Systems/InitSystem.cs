using UnityEngine;
using Leopotam.Ecs;

public class InitSystem: Injects, IEcsInitSystem
{
    public void Init()
    {
        foreach(SlotActor slot in SceneData.Slots)
        {
            slot.Init(EcsWorld);
        }
        UI.SpawnDiceMono.Init(EcsWorld);
    }
}
