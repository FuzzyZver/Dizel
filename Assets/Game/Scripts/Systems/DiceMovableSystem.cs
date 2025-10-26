using UnityEngine;
using Leopotam.Ecs;

public class DiceMovableSystem: Injects, IEcsRunSystem
{
    private EcsFilter<DiceClickEvent> _diceClickEventFilter;

    private EcsEntity _currentDice;
    private bool _hasCurrentDice = false;
    private float _speed = 0.1f;

    public void Run()
    {
        foreach(int i in _diceClickEventFilter)
        {
            var dice = _diceClickEventFilter.Get1(i).Entity;
            if (!dice.Has<MovableFlag>()) return;
            if(_currentDice != dice || !_hasCurrentDice)
            {
                _currentDice = dice;
                _hasCurrentDice = true;
            }
            else if(_currentDice == dice)
            {
                _hasCurrentDice = false;
                EcsWorld.NewEntity().Get<DropDiceEvent>().Entity = dice;
            }
        }
        
        if(_hasCurrentDice)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 direction = Vector3.Lerp(_currentDice.Get<TransformRef>().Transform.position, mousePos, _speed);
            _currentDice.Get<TransformRef>().Transform.position = direction;
        }
    }
}
