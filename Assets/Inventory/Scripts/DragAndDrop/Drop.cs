using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag == null)
        {
            return;
        }

        ItemController item = eventData.pointerDrag.GetComponent<ItemController>();

        ManipulationOnObject(item);
    }



    protected virtual void ManipulationOnObject(ItemController controllItem)
    {
        
    }
}
