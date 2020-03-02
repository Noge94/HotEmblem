using System;
using UnityEngine;

namespace Code.Confguration
{ 
    [CreateAssetMenu(fileName = "EnemyUnits", menuName = "Omnidrone/EnemyUnitsConfiguration")]
    public class EnemyUnitsConfiguration : ScriptableObject
    {
        [SerializeField] private Unit _myrmidon;
        [SerializeField] private Unit _mage;
        [SerializeField] private Unit _knight;
        [SerializeField] private Unit _fighter;
        [SerializeField] private Unit _barbarian;
        
        
        public Unit GetBaseStats(UnitType unitType){
            switch (unitType)
            {
                case UnitType.Myrmidon:
                    return _myrmidon;
                case UnitType.Knight:
                    return _knight;
                case UnitType.Mage:
                    return _mage;
                case UnitType.Fighter:
                    return _fighter;
                case UnitType.Barbarian:
                    return _barbarian;
                default:
                    Debug.LogError("Enemy side has no base stats defined for the unit type "+ unitType);
                    return _barbarian;
            }
        }
    }
    
    

   
}