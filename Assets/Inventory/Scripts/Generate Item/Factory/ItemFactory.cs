using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Factory")]
public class ItemFactory : Factory
{

    [SerializeField] private ItemScriptableObject _appleItem;

    [SerializeField] private ItemScriptableObject _axeItem;
    [SerializeField] private ItemScriptableObject _armorItem;
    [SerializeField] private ItemScriptableObject _bootsItem;
    [SerializeField] private ItemScriptableObject _shieldItem;

    public override Item Get(TypeItem type, Transform parent)
    {
        switch (type)
        {
            case TypeItem.Apple:
                return Get(_appleItem.Prefabs, parent);
            case TypeItem.Axe:
                return Get(_axeItem.Prefabs, parent);
            case TypeItem.Armor:
                return Get(_armorItem.Prefabs, parent);
            case TypeItem.Boots:
                return Get(_bootsItem.Prefabs, parent);
            case TypeItem.Shield:
                return Get(_shieldItem.Prefabs, parent);
            default:
                return null;
        }
    }

    private T Get<T>(T obj, Transform parent) where T : Item
    {
        T instance = Instantiate(obj, parent);
        return instance;
    }


}
