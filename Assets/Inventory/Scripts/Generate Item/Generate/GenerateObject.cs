using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] private Transform _whereIsGenerateObject;

    [SerializeField] private List<ItemScriptableObject> _whatGenerates;

    [SerializeField] private Factory factory;

    [SerializeField] private int _countGenerate;

    [SerializeField] private UnityEngine.UI.Button _buttonGenerateItem;

    private void Start()
    {
        _buttonGenerateItem.onClick.AddListener(GenerateSingleItem);
        GenerateMultyItem();
    }



    private void GenerateMultyItem()
    {
        for(int i = 0; i < _countGenerate; i++)
        {
            GenerateSingleItem();
        }
    }

    private void GenerateSingleItem()
    {
        int index = GenerateIndex();
        Item item = factory.Get(_whatGenerates[index].Type, _whereIsGenerateObject);
    }

    private int GenerateIndex()
    {
        return Random.Range(0, _whatGenerates.Count);
    }
}
