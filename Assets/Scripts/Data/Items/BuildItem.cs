using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Data.Items
{
    public class BuildItem : BaseItem
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public ResourceValueItem[] BuildCost { get; private set; }

        public float BuildTime { get; private set; }

        public GameObject Prefab { get; private set; }

        //dont set a description because it useless for test demonstration
        public BuildItem(long _id, string _name, ResourceValueItem[] _cost, float _buildTime, string prefabAdress)
        {
            Id = _id;
            Name = _name;
            BuildCost = _cost;
            BuildTime = _buildTime;
            Prefab = Resources.Load<GameObject>("Prefabs/" + prefabAdress);
        }

        public bool IsCanBuild
        {
            get
            {
                return BuildCost.First((res) => 
                    res.Value - LocalData.Currencies.ResourceValues.First((res2) => res2.Model.Id == res.Model.Id).Value > 0
                ) == null && !LocalData.Buildings.MapBuildings.Any((building) => building.IsBuilded);
            }
        }
    }
}
