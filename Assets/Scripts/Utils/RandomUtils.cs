using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtils
{
    public static float Range(Vector2 range) => Random.Range(range.x, range.y);
}
