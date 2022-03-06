using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DebuggingUtils;

public class readPosY : DebuggingUtilsValueGetter
{
    public override float ReadValue()
    {
        return this.transform.position.y;
    }
}
