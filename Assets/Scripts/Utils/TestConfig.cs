using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConfig : Singleton<TestConfig>
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
        public int ModelId;
        public long Value;
        public long Storage;
    }

    [System.Serializable]
    public struct TempBuildingModel
    {
        public long Id;
        public string Name;
        public TempResourceItem[] Cost;
        public float BuildTime;
        public string PrefabAdress;
        public int[] Args;
    }

    public TempResourceModel[] tempResourceModels;
    public TempResourceItem[] tempResourceItems;
    public TempBuildingModel[] tempBuildingModels;

    public Action<TempResourceModel[]> OnResourceModelsReceive;
    public Action<TempResourceItem[]> OnResourceItemsReceive;
    public Action<TempBuildingModel[]> OnBuildingModelsReceive;

    public Action OnInitDataSuccess;
    IEnumerator Start()
    {
        OnResourceModelsReceive?.Invoke(tempResourceModels);
        yield return null;
        OnResourceItemsReceive?.Invoke(tempResourceItems);
        yield return null;
        OnBuildingModelsReceive?.Invoke(tempBuildingModels);
        OnInitDataSuccess?.Invoke();
    }

}
