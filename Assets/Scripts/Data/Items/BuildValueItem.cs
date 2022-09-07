using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class BuildValueItem : BaseItem
    {
        public long Id { get; private set; }

        public BuildItem Model { get; private set; }

        private bool isBuilded;
        public bool IsBuilded
        {
            get { return isBuilded; }
            set { 
                if(value && value != isBuilded)
                {
                    isBuilded = value;
                    lastUpdate = DateTime.UtcNow;
                    OnChangeItem?.Invoke();
                }
            }
        }

        private DateTime lastUpdate;

        public DateTime LastUpdate // set only Datetime.UtcNow
        {
            get { return lastUpdate; }
            set { 
                lastUpdate = value; // know that i can write DateTime.UtcNow instead value
                OnChangeItem?.Invoke();
            }
        }

        public BuildValueItem(long _id, BuildItem _model, bool _isBuilded, DateTime lastUpdate)
        {
            Id = _id;
            Model = _model;
            LastUpdate = lastUpdate;
            isBuilded = _isBuilded? _isBuilded : lastUpdate.AddSeconds(Model.BuildTime) < DateTime.UtcNow;
        }
    }
}
