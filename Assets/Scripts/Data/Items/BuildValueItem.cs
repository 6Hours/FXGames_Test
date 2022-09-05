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

        public bool IsBuilded { get; private set; }

        private DateTime lastUpdate;

        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { 
                lastUpdate = value;
                OnChangeItem?.Invoke();
            }
        }

        public BuildValueItem(long _id, BuildItem _model, bool _isBuilded, DateTime lastUpdate)
        {
            Id = _id;
            Model = _model;
            IsBuilded = _isBuilded? _isBuilded : lastUpdate.AddSeconds(Model.BuildTime) < DateTime.Now;
            LastUpdate = lastUpdate;
        }
    }
}
