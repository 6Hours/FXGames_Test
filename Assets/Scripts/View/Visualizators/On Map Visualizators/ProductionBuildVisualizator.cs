using Data;
using Data.Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace View.Visualizators.OnMap
{
    public class ProductionBuildVisualizator : BuildValueItemVisualizator
    {
        [SerializeField] private SpriteRenderer resourceReadyInicator; //spriteRenderer

        public override void DestroyBuilding()
        {
            
        }

        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            var tempItem = (Item as BuildValueItem);

            resourceReadyInicator.sprite = LocalData.Currencies.ResourceModels.First(
                (res) => res.Id == tempItem.Model.Args[1]).Icon;
            resourceReadyInicator.gameObject.SetActive(false);

            if (tempItem.IsBuilded)
            {
                CancelInvoke(); //suppport-costil

                Invoke("CheckState", Mathf.Max(0f,
                    (float)(tempItem.LastUpdate.AddSeconds(tempItem.Model.Args[0]) - System.DateTime.UtcNow).TotalSeconds));
            }
        }

        protected override void CheckState()
        {
            var tempItem = Item as BuildValueItem;
            //Args[0] is time of resource mining, Args[1] is Id of resourceModel, Args[2] is add storage value

            if (tempItem.IsBuilded)
            {
                resourceReadyInicator.gameObject.SetActive(true);
            }
            else
            {
                base.CheckState();
            }
        }

        private void OnMouseUpAsButton()
        {
            var tempItem = (Item as BuildValueItem);
            
            if(resourceReadyInicator.gameObject.activeSelf)
            {
                var result = LocalData.Currencies.StorageResourceValues.First((storRes) =>
                    storRes.Model.Id == tempItem.Model.Args[1]).AddResource(tempItem.Model.Args[2]);

                if(result)
                {
                    resourceReadyInicator.gameObject.SetActive(false);
                    tempItem.LastUpdate = System.DateTime.UtcNow;
                }
            }
        }
    }
}
