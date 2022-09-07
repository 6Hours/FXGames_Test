using Data.Items.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Data
{
    public class Currencies
    {
        public ResourceItem[] ResourceModels { get; private set; }

        public ResourceStorageItem[] StorageResourceValues { get; private set; }

        public void Initialize()
        {
            TestConfig.Instance.OnResourceModelsReceive += LoadModelsData;
            TestConfig.Instance.OnResourceItemsReceive += LoadValuesData;
        }

        private void LoadModelsData(TestConfig.TempResourceModel[] _models)
        {
            ResourceModels = new ResourceItem[_models.Length];
            for(var i = 0; i < _models.Length; i++)
            {
                ResourceModels[i] = new ResourceItem(_models[i].Id, _models[i].Name, _models[i].IconAdress);
            }
        }

        private void LoadValuesData(TestConfig.TempResourceItem[] _items)
        {
            StorageResourceValues = new ResourceStorageItem[_items.Length];
            for (var i = 0; i < _items.Length; i++)
            {
                StorageResourceValues[i] = new ResourceStorageItem(
                    ResourceModels.First((model) => model.Id == _items[i].ModelId),
                    _items[i].Value,
                    _items[i].Storage);
            }
        }
    }
}
