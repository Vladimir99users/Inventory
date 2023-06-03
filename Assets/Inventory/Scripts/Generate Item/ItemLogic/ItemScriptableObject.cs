using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item" )]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private Item _prefabs;
    [SerializeField] private Vector2 _razmer  = new Vector2(1,1);
    [SerializeField] private TypeItem _typeItem;


    public Item Prefabs => _prefabs;
    public TypeItem Type => _typeItem;
    public int X => (int)_razmer.x;
    public int Y => (int)_razmer.y;

}
