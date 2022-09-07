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
        private void Start()
        {
            mapController = FindObjectOfType<MapController>();
            mapController.OnBuildingFinished += OnBuildFinfished;

            FindObjectOfType<TestConfig>().OnInitDataSuccess += Initialize;

            shopScreen.Initialize();
            shopScreen.OnItemClick += OnBuildClick;

            shopButton.onClick.AddListener(OnShopClick);
        }

        private void Initialize()
        {
            headerResourceStorages.SetItemsGroup(LocalData.Currencies.StorageResourceValues);
        }

        private void OnBuildClick(BuildItem item)
        {
            mapController.SetBuildState(item);
            shopScreen.Hide();
        }

        private void OnShopClick()
        {
            mapController.SetNormalState();
            shopScreen.Show();
        }

        private void OnBuildFinfished()
        {
            shopScreen.UpdateList();
        }
    }
}