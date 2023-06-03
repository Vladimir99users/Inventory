using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Factory : ScriptableObject
{
    public abstract Item Get(TypeItem type, Transform parent);
}
