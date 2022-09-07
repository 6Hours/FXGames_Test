using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace View.Visualizators.OnMap
{
    public abstract class BuildValueItemVisualizator : BaseItemVisualizator
    {
        [SerializeField] private GameObject buildingSupport; //indicator of building

        protected MapController mapController;
        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            var tempItem = (Item as BuildValueItem);

            buildingSupport.SetActive(!tempItem.IsBuilded);

            if(!tempItem.IsBuilded)
            {
                Invoke("CheckState", Mathf.Max(0,
                    (int)(tempItem.LastUpdate.AddSeconds(tempItem.Model.BuildTime) - System.DateTime.UtcNow).TotalSeconds));
            }
        }

        protected virtual void CheckState()
        {
            (Item as BuildValueItem).IsBuilded = true;
            mapController.OnBuildingFinished?.Invoke();
        }

        private void Start()
        {
            mapController = FindObjectOfType<MapController>();
        }

        public abstract void DestroyBuilding();
    }
}
