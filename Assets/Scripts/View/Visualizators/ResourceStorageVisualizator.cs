using Data.Items;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Data.Items.Resources;

namespace View.Visualizators
{
    public class ResourceStorageVisualizator : BaseItemVisualizator
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private string format = "{0}";

        public override void UpdateItem(BaseItem _item)
        {
            base.UpdateItem(_item);

            icon.sprite = (Item as ResourceStorageItem).Model.Icon;
            valueText.text = string.Format(format,
                (Item as ResourceStorageItem).Count.ToString(),
                (Item as ResourceStorageItem).StorageSpace.ToString());
        }
    }
}