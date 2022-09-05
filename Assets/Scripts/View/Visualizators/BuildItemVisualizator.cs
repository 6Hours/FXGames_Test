using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace View.Visualizators
{
    public class BuildItemVisualizator : BaseItemVisualizator
    {
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private TextMeshProUGUI buildTime;
        [SerializeField] private VisualizatorsList costList;
        [SerializeField] private Button buildIt;

        private void Start()
        {
            buildIt.onClick.AddListener(OnClick);
        }
        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            name.text = (Item as BuildItem).Name;
            description.text = (Item as BuildItem).Description;
            buildTime.text = (Item as BuildItem).BuildTime.ToString() + "s";
            costList.SetItemsGroup((Item as BuildItem).BuildCost);

            buildIt.gameObject.SetActive((Item as BuildItem).IsCanBuild);
        }

        private void OnClick()
        {
            OnValueChanged?.Invoke(this);
        }
    }
}
