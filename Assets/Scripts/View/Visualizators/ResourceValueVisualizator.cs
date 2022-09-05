using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace View.Visualizators
{
    public class ResourceValueVisualizator : BaseItemVisualizator
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI valueText;

        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            icon.sprite = (Item as ResourceValueItem).Model.Icon;
            valueText.text = (Item as ResourceValueItem).Value.ToString();
        }
    }
}