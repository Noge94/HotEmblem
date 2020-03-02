using System;
using UnityEngine;

namespace Code.Confguration
{ 
    [CreateAssetMenu(fileName = "PlayerUnits", menuName = "Omnidrone/PlayerUnitsConfiguration")]
    public class PlayerUnitsConfiguration : ScriptableObject
    {
        [SerializeField] private Unit _lord;
        [SerializeField] private Unit _cavalier;
        [SerializeField] private Unit _myrmidon;
        [SerializeField] private Unit _mage;
        [SerializeField] private Unit _knight;
        [SerializeField] private Unit _fighter;
        
        public Unit GetBaseStats(UnitType unitType){
            switch (unitType)
            {
                case UnitType.Myrmidon:
                    return _myrmidon;
                case UnitType.Lord:
                    return _lord;
                case UnitType.Cavalier:
                    return _cavalier;
                case UnitType.Knight:
                    return _knight;
                case UnitType.Mage:
                    return _mage;
                case UnitType.Fighter:
                    return _fighter;
                default:
                    Debug.LogError("Player side has no base stats defined for the unit type "+ unitType);
                    return _cavalier;
            }
        }
    }

   
}