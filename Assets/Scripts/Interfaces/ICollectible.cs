using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
    Transform transform { get; }
    void Collect();
}
