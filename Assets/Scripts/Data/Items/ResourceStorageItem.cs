using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items.Resources
{
    public class ResourceStorageItem : BaseItem
    {
        public ResourceItem Model { get ; private set; }
        public long Count { get; private set; }

        private long storageSpace = 150;

        public long StorageSpace
        {
            get { return storageSpace; }
            set { 
                storageSpace = value;
                OnChangeItem?.Invoke();
            }
        }

        public ResourceStorageItem(ResourceItem _resource, long _count, long _storage)
        {
            Model = _resource;
            Count = _count;
            storageSpace = _storage;
        }

        public bool AddResource(long value)
        {
            if (Count + value > storageSpace) return false;
            if (Count - value < 0) return false;
            Count += value;
            return true;
        }
    }
}
