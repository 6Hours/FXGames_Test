using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class ResourceItem : BaseItem
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public Sprite Icon { get; private set; }

        public ResourceItem(long _id, string _name, string _icon)
        {
            Id = _id;
            Name = _name;
            Icon = Resources.Load<Sprite>("Sprites/Resources/" + _icon);
        }
    }
}
