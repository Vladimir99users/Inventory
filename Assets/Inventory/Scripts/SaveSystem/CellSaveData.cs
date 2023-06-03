using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellSaveData
{
    public int Index;
    public TypeItem Type;
}

[System.Serializable]
public class CellsData
{
    public CellSaveData[] _cellsData;

    public CellsData()
    {
        
    }
}
