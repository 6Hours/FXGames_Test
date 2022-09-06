using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class ResourceValueItem : BaseItem
    {
        public ResourceItem Model { get; private set; }

        private long count = 0;

        public long Value
        {
            get { return count; }
            set
            {
                count = value;
                OnChangeItem.Invoke();
            }
        }

        public ResourceValueItem(ResourceItem _resource, long _count)
        {
            Model = _resource;
            count = _count;
        }
    }
}
