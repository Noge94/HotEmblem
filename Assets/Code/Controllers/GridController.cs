using Code.Models;

namespace Code.Controllers
{
    public class GridController
    {
        private GridModel _gridModel;
        private LevelManager _levelManager;
        
        public GridController(GridView gridView, LevelManager levelManager)
        {
            _levelManager = levelManager;
            _gridModel = new GridModel(gridView, _levelManager.Columns, _levelManager.Rows);
            _gridModel.SpawnPlayerUnits(_levelManager.GetPlayerUnits());
            _gridModel.SpawnEnemyUnits(_levelManager.GetEnemyUnits());
        }
        
        public void CellSelected(GridPosition gridPosition)
        {
            _gridModel.CellSelected(gridPosition);
        }
    }
}