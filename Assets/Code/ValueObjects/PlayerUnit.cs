using System;

namespace Code
{
    [Serializable]
    public class PlayerUnit : Unit
    {
        public PlayerUnit(GridPosition gridPosition, UnitType type, Unit baseStats)
        {
            Position = gridPosition;
            _side = UnitSide.Player;
            _type = type;
            HealthPoints = baseStats.HealthPoints;
            AttackPoints = baseStats.AttackPoints;
            AttackRange = baseStats.AttackRange;
            MoveRange = baseStats.MoveRange;
            Sprite = baseStats.Sprite;
        }
    }
}