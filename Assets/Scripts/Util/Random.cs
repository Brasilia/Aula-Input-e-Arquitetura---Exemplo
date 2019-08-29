using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class Random
    {
        public static bool Test(float chance)
        {
            return (UnityEngine.Random.Range(0f, 1f) < chance);
        }
    }
}


