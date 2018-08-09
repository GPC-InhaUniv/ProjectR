using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.GameSystem
{
    public enum ItemType
    {
        Cow = 0,
        Iron = 1,
        Soil = 2,
        Water = 3,
        Wheat = 4,
        Wood = 5,
    }

    static class GlobalVariables
    {
        public const int tileGridSize = 9;
        public const int minZIntercept = 3;
        public const int maxZIntercept = 13;
    }
}