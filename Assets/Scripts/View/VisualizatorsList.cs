using Data.Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using View.Visualizators;

namespace View
{
    [System.Serializable]
    public class VisualizatorsList
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private BaseItemVisualizator prefab;

        public System.Action<BaseItemVisualizator> OnValueChanged;
        public List<BaseItemVisualizator> Visualizators { get; private set; } = new List<BaseItemVisualizator>();

        public void SetItemsGroup(BaseItem[] _items)
        {
            for (var i = 0; i < Mathf.Max(Visualizators.Count, _items.Length); i++)
            {
                if (i >= Visualizators.Count)
                {
                    Visualizators.Add(MonoBehaviour.Instantiate(prefab, container));
                    Visualizators.Last().OnValueChanged += InvokeCallback;
                }

                Visualizators[i].gameObject.SetActive(i < _items.Length);

                if (i < _items.Length)
                {
                    Visualizators[i].UpdateItem(_items[i]);
                }
            }
        }

        private void InvokeCallback(BaseItemVisualizator _visualizator)
        {
            OnValueChanged?.Invoke(_visualizator);
        }
    }
}
