using System;
using Code.Controllers;
using UnityEngine;
using UnityEngine.Analytics;

namespace Code
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private GameObject _cellPrefab;

        private GridController _gridController;
        
        private CellView[,] _cells;

        private void Start()
        {
            _gridController = new GridController(this, LevelManager.Instance);
        }

        public void InitializeUnits(PlayerUnit[] playerUnits, EnemyUnit[] enemyUnits)
        {
           
        }

        public void InitializeGrid(int columns, int rows)
        {
            _cells = new CellView[columns, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    _cells[col, row] = Instantiate(
                        _cellPrefab,
                        transform.position + new Vector3(col, row, 0),
                        Quaternion.identity,
                        transform
                    ).GetComponent<CellView>();

                    _cells[col, row].Init(col, row);
                    _cells[col, row].OnTouch += CellSelected;
                }
            }
        }

        private void CellSelected(object sender, GridPosition p)
        {
            _gridController.CellSelected(p);
        }

        public void Draw(Unit unit)
        {
            _cells[unit.Column, unit.Row].Draw(unit);
        }

        public void HighlightCell(GridPosition pos)
        {
            _cells[pos.Column, pos.Row].Highlight();
        }

        public void ResetCellColor(GridPosition pos)
        {
            _cells[pos.Column, pos.Row].ResetColor();
        }

        public void ClearCell(int col, int row)
        {
            _cells[col, row].Clear();
        }
    }
}