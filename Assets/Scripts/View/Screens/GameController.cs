using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using View.Screens;
using View;
using Data;
using Utils;

namespace UI
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ShopScreen shopScreen;
        [SerializeField] private Button shopButton;
        [SerializeField] private VisualizatorsList headerResourceStorages;

        private MapController mapController;

        // Start is called before the first frame update
        void Start()
        {
            shopScreen.Initialize();
            shopScreen.OnItemClick += OnBuildClick;

            shopButton.onClick.AddListener(BackToMain);
            shopButton.gameObject.SetActive(false);

            headerResourceStorages.SetItemsGroup(LocalData.Currencies.StorageResourceValues);

            mapController = FindObjectOfType<MapController>();
        }

        private void OnBuildClick(BuildItem item)
        {
            shopScreen.Hide();
            shopButton.gameObject.SetActive(true);
        }

        private void BackToMain()
        {
            shopButton.gameObject.SetActive(false);

        }
    }
}