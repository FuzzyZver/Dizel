using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

public class RollDiceSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<RollDiceEvent> _rollDiceEventFilter;
    private DiceActor _dicePrefab;
    private List<Sprite> _diceSprites = new List<Sprite>();

    public void Init()
    {
        _dicePrefab = GameConfig.DiceConfig.DicePrefab;
        _diceSprites = GameConfig.DiceConfig.DiceSprites;
    }

    public void Run()
    {
        foreach(int i in _rollDiceEventFilter)
        {
            EcsWorld.NewEntity().Get<ChangeTurnEvent>();
            DiceActor dice = GameObject.Instantiate(_dicePrefab, SceneData.DiceSpawnPoint);
            dice.Init(EcsWorld);
            var diceEntity = dice.GetEntity();
            int value = Random.Range(1, 7);
            diceEntity.Get<DiceValue>().Value = value;
            diceEntity.Get<SpriteRendererRef>().SpriteRenderer.sprite = _diceSprites[value];
        }
    }
}
