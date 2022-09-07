using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace View.Visualizators.OnMap
{
    public abstract class BuildValueItemVisualizator : BaseItemVisualizator
    {
        [SerializeField] private GameObject buildingSupport; //incator of building

        protected MapController mapController;
        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            var tempItem = (Item as BuildValueItem);

            buildingSupport.SetActive(!tempItem.IsBuilded);

            if(!tempItem.IsBuilded)
            {
                Invoke("OnStateChange", Mathf.Max(0,
                    (int)(tempItem.LastUpdate.AddSeconds(tempItem.Model.BuildTime) - System.DateTime.Now).TotalSeconds));
            }
        }

        protected virtual void CheckState()
        {
            if(!(Item as BuildValueItem).IsBuilded)
            {
                (Item as BuildValueItem).IsBuilded = true;
                buildingSupport.SetActive(false);
                mapController.OnBuildingFinished?.Invoke();
            }
        }
        void Start()
        {
            mapController = FindObjectOfType<MapController>();

        }

        public abstract void DestroyBuilding();
    }
}
