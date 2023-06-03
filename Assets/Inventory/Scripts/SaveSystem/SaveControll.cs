using System.Collections.Generic;
using UnityEngine;

public class SaveControll : MonoBehaviour
{
    [SerializeField] private GenerateGrid _gridData;

    private void OnEnable() 
    {
        if(IOSystem.IsCheckFile() == false) return;


        _gridData.SetDataCell();
    }
    public void Save()
    {
        List<CellSaveData> cells = new List<CellSaveData>();

        foreach (var cellData in _gridData.Cells)
        {
            if(cellData.GetComponentInChildren<Item>() != null) 
            {
                CellSaveData data = new CellSaveData
                {
                    Index = cellData.Index,
                    Type = cellData.Type
                };

                cells.Add(data);
            }
        }

        IOSystem.SaveData(cells);
    }
}
