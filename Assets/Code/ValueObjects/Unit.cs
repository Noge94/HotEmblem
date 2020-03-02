using System;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class Unit
    {
        public GridPosition Position;
        protected UnitSide _side;
        protected UnitType _type;
        public int HealthPoints, AttackPoints, AttackRange, MoveRange;
        public Sprite Sprite;
        
        public UnitSide Side {get { return _side;}}
        public int Row {get { return Position.Row;}}
        public int Column {get { return Position.Column;}}

        public bool CanMoveTo(int col, int row)
        {
            int distance;
            distance = Mathf.Abs(Position.Column - col) + Mathf.Abs(Position.Row - row);
            return distance <= MoveRange;
        }

        public bool CanMoveTo(GridPosition gridPosition)
        {
            return CanMoveTo(gridPosition.Column,gridPosition.Row);
        }
    }

    
    public enum UnitSide
    {
        Player,
        Enemy
    }
    
    public enum UnitType
    {
        Lord,
        Cavalier,
        Myrmidon,
        Knight,
        Mage,
        Fighter,
        Barbarian
    }
}