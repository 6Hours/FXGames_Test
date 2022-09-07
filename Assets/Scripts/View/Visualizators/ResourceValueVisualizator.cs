using Data.Items;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items.Resources;

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
            valueText.text = (Item as ResourceValueItem).Count.ToString();
        }
    }
}