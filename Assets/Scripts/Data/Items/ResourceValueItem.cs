using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class ResourceValueItem : BaseItem
    {
        public long Id { get; private set; }

        public ResourceItem Resource { get; private set; }

        private int count = 0;

        public int Value
        {
            get { return count; }
            set
            {
                count = value;
                OnChangeItem.Invoke();
            }
        }

        public ResourceValueItem(long _id, ResourceItem _resource, int _count)
        {
            Id = _id;
            Resource = _resource;
            count = _count;
        }
    }
}
