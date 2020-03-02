using System;
using Code;
using UnityEngine;

public class CellView : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _terrainRenderer;
	[SerializeField] private SpriteRenderer _unitRenderer;
	private GridPosition _cellGridPosition;

	public event EventHandler<GridPosition> OnTouch;
	
	public void OnMouseDown()
	{
		_terrainRenderer.color = Color.white;
	}
	
	public void OnMouseUp()
	{
		ResetColor();
		HandleOnTouch();
	}

	private void HandleOnTouch()
	{
		EventHandler<GridPosition> handler = OnTouch;
		if (handler != null)
		{
			handler(this, _cellGridPosition);
		}
	}

	private void SetObjectName(string s)
	{
		gameObject.name = s;
	}

	public void ResetColor()
	{
		_terrainRenderer.color = 
			(_cellGridPosition.Column + _cellGridPosition.Row) % 2 == 0 ?
			Color.grey/2f : Color.grey;
	}

	public void Init(int col, int row)
	{
		_cellGridPosition = new GridPosition(col, row);
		
		SetObjectName("cell " + col + "-" + row);
		ResetColor();
	}

	public void Draw(Unit unit)
	{
		ResetColor();
		_unitRenderer.gameObject.SetActive(true);
		_unitRenderer.sprite = unit.Sprite;
	}

	public void Clear()
	{
		ResetColor();
		_unitRenderer.gameObject.SetActive(false);
	}

	public void Highlight()
	{
		ResetColor();
		_terrainRenderer.color = _terrainRenderer.color + Color.cyan/2f;
	}

}
