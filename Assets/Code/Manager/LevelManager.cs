using Boo.Lang;
using Code.Confguration;
using UnityEngine;

namespace Code
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; set; }
        
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private PlayerUnitsConfiguration _playerUnitsConfguration;
        [SerializeField] private EnemyUnitsConfiguration _enemyUnitsConfguration;

        public int Rows {get { return _levelConfiguration.Rows;}}
        public int Columns {get { return _levelConfiguration.Columns;}}

        private void OnDestroy()
        {
            Instance = null;
        }

        public PlayerUnit[] GetPlayerUnits()
        {
            PlayerUnit[] playerUnits = new PlayerUnit[_levelConfiguration.PlayerUnits.Length];

            for (int i = 0; i < playerUnits.Length; i++)
            {
                GridPosition gridPosition = new GridPosition(_levelConfiguration.PlayerUnits[i].X, _levelConfiguration.PlayerUnits[i].Y);
                UnitType unitType = _levelConfiguration.PlayerUnits[i].UnitType;
                Unit baseStats = _playerUnitsConfguration.GetBaseStats(unitType);
                playerUnits[i] = new PlayerUnit(gridPosition, unitType, baseStats);
            }

            return playerUnits;
        }
        public EnemyUnit[] GetEnemyUnits()
        {
            EnemyUnit[] enemyUnits = new EnemyUnit[_levelConfiguration.EnemyUnits.Length];

            for (int i = 0; i < enemyUnits.Length; i++)
            {
                GridPosition gridPosition = new GridPosition(_levelConfiguration.EnemyUnits[i].X, _levelConfiguration.EnemyUnits[i].Y);
                UnitType unitType = _levelConfiguration.EnemyUnits[i].UnitType;
                Unit baseStats = _enemyUnitsConfguration.GetBaseStats(unitType);
                enemyUnits[i] = new EnemyUnit(gridPosition, unitType, baseStats);
            }

            return enemyUnits;
        }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There are multiple Level components");
            }
            Instance = this;
        }
    }
}