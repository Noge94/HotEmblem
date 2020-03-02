using System.Collections.Generic;
using UnityEngine;

namespace Code.Models
{
    public class GridModel
    {
        private readonly GridView _gridView;
        private Unit[,] _grid;
        private List<PlayerUnit> _playerUnits;
        private List<EnemyUnit> _enemyUnits;

        private int _totalColumns;
        private int _totalRows;
        private Unit _selectedUnit;


        public GridModel(GridView gridView, int columns, int rows)
        {
            _gridView = gridView;
            _totalColumns = columns;
            _totalRows = rows;
            _playerUnits = new List<PlayerUnit>();
            _enemyUnits = new List<EnemyUnit>();
            _grid = new Unit[columns,rows];
            gridView.InitializeGrid(columns, rows);
        }

        public void SpawnPlayerUnits(PlayerUnit[] units)
        {
            foreach (var unit in units)
            {
                if (_grid[unit.Column, unit.Row] == null)
                {
                    _playerUnits.Add(unit);
                    _grid[unit.Column, unit.Row] = unit;
                    _gridView.Draw(unit);
                }
            }
        }
        
        public void SpawnEnemyUnits(EnemyUnit[] units)
        {
            foreach (var unit in units)
            {
                if (_grid[unit.Column, unit.Row] == null)
                {
                    _enemyUnits.Add(unit);
                    _grid[unit.Column, unit.Row] = unit;
                    _gridView.Draw(unit);
                }
            }
        }

        public void CellSelected(GridPosition gridPosition)
        {
            Unit selectedCell = _grid[gridPosition.Column, gridPosition.Row];
            if (selectedCell == null)
            {
                if (_selectedUnit != null )
                {
                    ResetallCellsColor();
                    if (_selectedUnit.CanMoveTo(gridPosition))
                    {
                        MoveUnitTo(_selectedUnit, gridPosition);
                    }
                    else
                    {
                        _selectedUnit = null;
                    }
                }
            } 
            
            if (selectedCell != null && selectedCell.Side == UnitSide.Player)
            {
                ShowMoveRange(selectedCell);
            }
        }

        private void MoveUnitTo(Unit selectedUnit, GridPosition gridPosition)
        {
            _gridView.ClearCell(selectedUnit.Column, selectedUnit.Row);
            _grid[selectedUnit.Column, selectedUnit.Row] = null;
            _grid[gridPosition.Column, gridPosition.Row] = selectedUnit;
            selectedUnit.Position = gridPosition;
            _gridView.Draw(selectedUnit);
        }

        private void ResetallCellsColor()
        {
            for (int col = 0; col < _totalColumns; col++)
            {
                for (int row = 0; row < _totalRows; row++)
                {
                    _gridView.ResetCellColor(new GridPosition(col, row));
                }
            }
        }

        private void ShowMoveRange(Unit selectedCell)
        {
            _selectedUnit = selectedCell;
            for (int col =0; col < _totalColumns; col++)
            {
                for (int row = 0; row < _totalRows; row++)
                {
                    if (_selectedUnit.CanMoveTo(col, row) && _grid[col,row] == null)
                    {
                        _gridView.HighlightCell(new GridPosition(col, row));
                    }
                    else
                    {
                        _gridView.ResetCellColor(new GridPosition(col, row));
                    }
                    
                }
            }
        }

        private bool ColumnOutOfBounds(Unit selectedUnit, int col)
        {
            return selectedUnit.Column + col < 0|| selectedUnit.Column + col >= _totalColumns;
        }

        private bool RowOutOfBounds(Unit selectedUnit, int row)
        {
            return selectedUnit.Row + row < 0 || selectedUnit.Row + row >= _totalRows;
        }
    }
}