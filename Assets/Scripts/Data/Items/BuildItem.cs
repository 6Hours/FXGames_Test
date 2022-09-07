using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Data.Items.Resources;

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

        public int[] Args { get; private set; }

        //dont set a description because it useless for test demonstration
        public BuildItem(long _id, string _name, ResourceValueItem[] _cost, float _buildTime, string _prefabAdress, int[] _args)
        {
            Id = _id;
            Name = _name;
            BuildCost = _cost;
            BuildTime = _buildTime;
            Prefab = UnityEngine.Resources.Load<GameObject>("Prefabs/" + _prefabAdress);
            Args = _args;
        }

        public bool IsCanBuild
        {
            get
            {
                return BuildCost.First((res) => 
                    res.Count - LocalData.Currencies.StorageResourceValues.First((res2) => res2.Model.Id == res.Model.Id).Count > 0
                ) == null && !LocalData.Buildings.MapBuildings.Any((building) => !building.IsBuilded);
            }
        }
    }
}
