using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool
{
    // get round value 
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));
    }
}
