using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items.Resources
{
    public class ResourceValueItem : BaseItem
    {
        public ResourceItem Model { get; private set; }

        public long Count { get; private set;}

        public ResourceValueItem(ResourceItem _resource, long _count)
        {
            Model = _resource;
            Count = _count;
        }
    }
}
