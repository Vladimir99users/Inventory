using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateGrid : MonoBehaviour
{

    [Header("Generated mesh size")]

    [SerializeField] private int _heigh;
    [SerializeField] private int _wight;

    [Header("Prefabs cell ")]
    [SerializeField] private Cell _cellPrefabs;

    [Header("Generate Parent position")]
    [SerializeField] private Transform _whatIsMyParent;

    [SerializeField] private Factory factory;


    [SerializeField] private List<Cell> _cells = new List<Cell>();

    public List<Cell> Cells { get => _cells;  }

    private void Awake() 
    {
        Grid grid = new Grid(_heigh, _wight);
        GenerateVisualGrid(grid);


    }

    public void SetDataCell()
    {
        List<CellSaveData> datas = IOSystem.LoadData<CellSaveData>();

        foreach (var item in datas)
        {
            if(_cells[item.Index].gameObject.transform.childCount != 0)  return;

            factory.Get(item.Type, _cells[item.Index].transform);
        }
    }

    private void GenerateVisualGrid(Grid grid)
    {
        int i = 0;
        for (int x = 0; x < grid.GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GridArray.GetLength(1); y++)
            {
                Cell cell = Instantiate(_cellPrefabs, GetWorldPosition(_cellPrefabs,x, y, y), Quaternion.identity, _whatIsMyParent);
                cell.Init(i);
                cell.gameObject.name = $"Cell = {i}";
                i++;
                _cells.Add(cell);
            }
        }
    }


    private Vector3 GetWorldPosition(Cell cell, int x = 0, int y = 0, int z =0)
    {
        Vector3 position = new Vector3();
        position = _whatIsMyParent.position;
        return new Vector3(position.x + x * cell.CellSize.x, position.y + y * cell.CellSize.y, position.z + y * cell.CellSize.z);
    }
}
