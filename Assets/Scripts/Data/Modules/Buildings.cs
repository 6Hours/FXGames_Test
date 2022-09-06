using Data.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Data
{
    public class Buildings
    {
        public BuildItem[] BuildingModels { get; private set; }

        public List<BuildValueItem> MapBuildings { get; private set; }

        public void Initialize()
        {
            TestConfig.Instance.OnBuildingModelsReceive += LoadModelsData;
        }

        private void LoadModelsData(TestConfig.TempBuildingModel[] _models)
        {
            BuildingModels = new BuildItem[_models.Length];
            for(var i = 0; i < _models.Length; i++)
            {
                var costList = new ResourceValueItem[_models[i].Cost.Length];
                for(var j = 0; j < _models[i].Cost.Length; j++)
                    costList[j] = new ResourceValueItem(
                        LocalData.Currencies.ResourceModels.First((model) => model.Id == _models[i].Cost[j].ModelId),
                        _models[i].Cost[j].Value);

                BuildingModels[i] = new BuildItem(
                    _models[i].Id,
                    _models[i].Name,
                    costList,
                    _models[i].BuildTime,
                    _models[i].PrefabAdress,
                    _models[i].Args);
            }
        }

        private void LoadProgressData()
        {
            ///havent reason for realisation, because of test
        }
    }
}
