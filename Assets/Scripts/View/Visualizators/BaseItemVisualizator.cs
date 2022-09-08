using Data.Items;
using UnityEngine;

namespace View.Visualizators
{
    public abstract class BaseItemVisualizator : MonoBehaviour
    {
        public System.Action<BaseItemVisualizator> OnValueChanged;
        private BaseItem item;
        
        public virtual void UpdateItem(BaseItem _item)
        {
            if (_item == item) return;

            if (item != null) item.OnChangeItem -= () => UpdateItem(item);
            item = _item;
            item.OnChangeItem += () => UpdateItem(item);
        }

        public BaseItem Item => item;
    }
}