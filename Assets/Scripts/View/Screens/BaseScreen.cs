using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View.Screens
{
    [System.Serializable]
    public abstract class BaseScreen : MonoBehaviour
    {
        [SerializeField] protected RectTransform screenRoot;

        public abstract void Initialize();

        public virtual void Show()
        {
            screenRoot.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            screenRoot.gameObject.SetActive(false);
        }

        protected virtual void OnShowComplete()
        {

        }

        protected virtual void OnHideComplete()
        {

        }
    }
}