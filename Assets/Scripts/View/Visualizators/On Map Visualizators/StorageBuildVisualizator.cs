using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View.Visualizators.OnMap
{
    public class StorageBuildVisualizator : BuildValueItemVisualizator
    {
        public override void DestroyBuilding()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            if((Item as BuildValueItem).IsBuilded)
            {

            }
        }
    }
}
