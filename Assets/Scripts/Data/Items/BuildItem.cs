using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class BuildItem : BaseItem
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public ResourceValueItem[] BuildCost { get; private set; }

        public float BuildTime { get; private set; }

        public GameObject Prefab { get; private set; }

        public BuildItem(long _id, string _name, ResourceValueItem[] _cost, float _buildTime, string prefabAdress)
        {
            Id = _id;
            Name = _name;
            BuildCost = _cost;
            BuildTime = _buildTime;
            Prefab = Resources.Load<GameObject>("Prefabs/" + prefabAdress);
        }
    }
}
