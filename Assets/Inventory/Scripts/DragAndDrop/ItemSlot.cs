using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : Drop
{
    protected override void ManipulationOnObject(ItemController controllItem)
    {

        if (controllItem == null) return;

        if (transform.childCount == 0)
        {
            controllItem.ParentAfterDrag = transform;
        }
    }

}
