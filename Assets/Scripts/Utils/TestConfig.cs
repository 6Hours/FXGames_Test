using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConfig : MonoBehaviour
{
    [System.Serializable]
    public struct TempResourceModel
    {
        public long Id;
        public string Name;
        public string IconAdress;
    }

    [System.Serializable]
    public struct TempResourceItem
    {
        public long Id;
        public int ModelId;
        public long Value;
    }

    [System.Serializable]
    public struct TempBuildingModel
    {
        public long Id;
        public string Name;
        public TempResourceItem[] Cost;
        public float BuildTime;
        public string PrefabAdress;
    }

    [System.Serializable]
    public struct TempBuildingItem
    {
        public long Id;
        public int ModelId;
        public bool IsBuilded;
        //havent value of LastUpdated because its a test and we havent progress yet
    }

    public TempResourceModel[] tempResourceModels;
    public TempResourceItem[] tempResourceItems;
    public TempBuildingModel[] tempBuildingModels;
    public TempBuildingItem[] tempBuildingItems;

    public Action<TempResourceModel[]> OnResourceModelsReceive;
    public Action<TempResourceItem[]> OnResourceItemsReceive;
    public Action<TempBuildingModel[]> OnBuildingModelsReceive;
    public Action<TempBuildingItem[]> OnBuildingItemsReceive;

    IEnumerator Start()
    {
        OnResourceModelsReceive?.Invoke(tempResourceModels);
        yield return null;
        OnResourceItemsReceive?.Invoke(tempResourceItems);
        yield return null;
        OnBuildingModelsReceive?.Invoke(tempBuildingModels);
        yield return null;
        OnBuildingItemsReceive?.Invoke(tempBuildingItems);
    }

}
