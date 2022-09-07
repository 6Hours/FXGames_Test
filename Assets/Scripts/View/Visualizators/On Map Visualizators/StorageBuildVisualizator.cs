using Data;
using Data.Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace View.Visualizators.OnMap
{
    public class StorageBuildVisualizator : BuildValueItemVisualizator
    {
        public override void DestroyBuilding()
        {
            var tempItem = (Item as BuildValueItem);
            if (tempItem.IsBuilded)
            {
                LocalData.Currencies.StorageResourceValues
                    .First((res) => res.Model.Id == tempItem.Model.Args[0]).StorageSpace -= tempItem.Model.Args[1];
            }
        }

        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);
            // Args[0] is Id of resourceModel, Args[1] is add storage value

            var tempItem = (Item as BuildValueItem);
            if (tempItem.IsBuilded)
            {
                LocalData.Currencies.StorageResourceValues
                    .First((res) => res.Model.Id == tempItem.Model.Args[0]).StorageSpace += tempItem.Model.Args[1];
            }
        }
    }
}
