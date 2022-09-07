using Data;
using Data.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View.Visualizators.OnMap;
using System.Linq;

namespace Utils
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private Material normalStateMaterial;
        [SerializeField] private Material buildStateMaterial;

        public System.Action OnBuildingFinished;
        public System.Action<BuildValueItemVisualizator> OnBuildClicked;

        private MeshRenderer meshRenderer;
        private BuildItem currentBuild; //temp item that you chose in the shop for building

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetBuildState(BuildItem item)
        {
            meshRenderer.material = buildStateMaterial;
            currentBuild = item;
        }

        private void SetNormalState()
        {
            meshRenderer.material = normalStateMaterial;
            currentBuild = null;
        }

        private void OnMouseUpAsButton()
        {
            if(currentBuild != null)
            {
                var tempItem = new BuildValueItem(LocalData.Buildings.MapBuildings.Count + 1,
                    currentBuild, false, DateTime.UtcNow);

                foreach(var res in tempItem.Model.BuildCost)
                    LocalData.Currencies.StorageResourceValues.First((stor) => stor.Model.Id == res.Model.Id).AddResource(res.Count);

                LocalData.Buildings.MapBuildings.Add(tempItem);

                Instantiate(tempItem.Model.Prefab,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                    Quaternion.identity, 
                    transform).GetComponent<BuildValueItemVisualizator>().UpdateItem(tempItem);
            }
        }
    }
}
