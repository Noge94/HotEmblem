using UnityEngine;

namespace Code.Confguration
{
    [CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Omnidrone/LevelConfiguration")]
    public class LevelConfiguration: ScriptableObject
    {
        public int Columns;
        public int Rows;
        
        public SpawnPoint[] PlayerUnits;
        public SpawnPoint[] EnemyUnits;
    }
}