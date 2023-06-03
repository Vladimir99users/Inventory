using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScrollMenu : Drop
{
    protected override void ManipulationOnObject(ItemController controllItem)
    {
        if (controllItem == null) return;

        controllItem.ParentAfterDrag = transform;
    }
}
