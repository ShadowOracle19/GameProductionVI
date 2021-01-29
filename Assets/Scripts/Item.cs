using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class Item : ScriptableObject
    {
        [Header("Item info")]
        public Sprite itemIcon;
        public string itemName;
    }
}

