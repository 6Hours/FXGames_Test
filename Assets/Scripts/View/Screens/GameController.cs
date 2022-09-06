using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using View.Screens;

namespace UI
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ShopScreen shopScreen;
        [SerializeField] private Button shopButton;

        // Start is called before the first frame update
        void Start()
        {
            shopScreen.Initialize();

            shopScreen.OnItemClick += OnBuildClick;

            shopButton.onClick.AddListener(BackToMain);
            shopButton.gameObject.SetActive(false);
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