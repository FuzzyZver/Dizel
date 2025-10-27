using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class CheckValueDiceSystem: Injects, IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<CheckValuesColumnEvent> _checkvaluesColunmEvent;
    private PlayerData _firstPlayer;
    private PlayerData _secondPlayer;

    public void Init()
    {
        _firstPlayer = SceneData.FirstPlayer;
        _secondPlayer = SceneData.SecondPlayer;
    }

    public void Run()
    {
        foreach (int i in _checkvaluesColunmEvent)
        {
            var evt = _checkvaluesColunmEvent.Get1(i);
            var diceEntity = evt.Entity;

            // Проверим, в каком столбце кубик
            bool isLeft = diceEntity.Has<LeftColumnFlag>();
            bool isCenter = diceEntity.Has<CentralColumnFlag>();
            bool isRight = diceEntity.Has<RightColumnFlag>();

            int diceValue = diceEntity.Get<DiceValue>().Value;

            // Определим, кого проверять
            List<SlotActor> enemySlots = null;
            if (RuntimeData.PlayerTurnId == 0)
            {
                // Ходит первый игрок → проверяем второго
                if (isLeft) enemySlots = _secondPlayer.LeftSlots;
                else if (isCenter) enemySlots = _secondPlayer.CentralSlots;
                else if (isRight) enemySlots = _secondPlayer.RightSlots;
            }
            else if (RuntimeData.PlayerTurnId == 1)
            {
                // Ходит второй игрок → проверяем первого
                if (isLeft) enemySlots = _firstPlayer.LeftSlots;
                else if (isCenter) enemySlots = _firstPlayer.CentralSlots;
                else if (isRight) enemySlots = _firstPlayer.RightSlots;
            }

            if (enemySlots == null)
            {
                Debug.LogWarning("Enemy slots not found for CheckValueDiceSystem");
                continue;
            }

            // Проверяем совпадения в противоположных слотах
            foreach (var slot in enemySlots)
            {
                if (!slot.GetEntity().Has<SlotStorage>())
                    continue;

                var enemyDiceEntity = slot.GetEntity().Get<SlotStorage>().Entity;

                if (!enemyDiceEntity.IsAlive() || !enemyDiceEntity.Has<DiceValue>())
                    continue;

                int enemyValue = enemyDiceEntity.Get<DiceValue>().Value;

                if (enemyValue == diceValue)
                {
                    // Уничтожаем кубик противника
                    Object.Destroy(enemyDiceEntity.Get<TransformRef>().Transform.gameObject);
                    enemyDiceEntity.Destroy();
                }
            }
        }
    }
}

   
