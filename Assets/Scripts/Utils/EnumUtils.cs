using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnumUtils : MonoBehaviour
{
    public static List<TEnum> GetEnumList<TEnum>() where TEnum : Enum
        => ((TEnum[])Enum.GetValues(typeof(TEnum))).ToList();
}
