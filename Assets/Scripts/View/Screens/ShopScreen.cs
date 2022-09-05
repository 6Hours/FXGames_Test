using Data;
using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View.Screens
{
    [System.Serializable]
    public class ShopScreen : BaseScreen
    {
        [SerializeField] private VisualizatorsList shopList;
        [SerializeField] private Button closeButton;

        public System.Action<BuildItem> OnItemClick;

        public override void Initialize()
        {
            shopList.OnValueChanged += (vis) => OnClick(vis.Item as BuildItem);
        }

        public override void Show()
        {
            base.Show();
            shopList.SetItemsGroup(LocalData.Buildings.BuildingModels);
        }

        public override void Hide()
        {
            base.Hide();
        }

        private void OnClick(BuildItem _item)
        {
            OnItemClick?.Invoke(_item);
        }
    }
}