using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private Vector3 _cellSize;

    public Vector3 CellSize { get => _cellSize; }
    public int Index { get => _index;}
    public Item Item {get => gameObject.GetComponentInChildren<Item>();}
    public TypeItem Type {get => gameObject.GetComponentInChildren<Item>().Type;}

    public void Init(int index) 
    {
        _index = index;
    }


}
