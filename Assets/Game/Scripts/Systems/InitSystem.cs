using UnityEngine;
using Leopotam.Ecs;

public class InitSystem: Injects, IEcsInitSystem
{
    public void Init()
    {
        foreach(SlotActor slot in SceneData.FirstPlayer.LeftSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<FirstPlayerFlag>();
            slot.GetEntity().Get<LeftColumnFlag>();
        }
        foreach (SlotActor slot in SceneData.FirstPlayer.CentralSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<FirstPlayerFlag>();
            slot.GetEntity().Get<CentralColumnFlag>();
        }
        foreach (SlotActor slot in SceneData.FirstPlayer.RightSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<FirstPlayerFlag>();
            slot.GetEntity().Get<RightColumnFlag>();
        }

        foreach (SlotActor slot in SceneData.SecondPlayer.LeftSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<SecondPlayerFlag>();
            slot.GetEntity().Get<LeftColumnFlag>();
        }
        foreach (SlotActor slot in SceneData.SecondPlayer.CentralSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<SecondPlayerFlag>();
            slot.GetEntity().Get<CentralColumnFlag>();
        }
        foreach (SlotActor slot in SceneData.SecondPlayer.RightSlots)
        {
            slot.Init(EcsWorld);
            slot.GetEntity().Get<SecondPlayerFlag>();
            slot.GetEntity().Get<RightColumnFlag>();
        }
        UI.SpawnDiceMono.Init(EcsWorld);
    }
}
