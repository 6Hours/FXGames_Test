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
        [SerializeField] private Button backButton;

        // Start is called before the first frame update
        void Start()
        {
            shopScreen.Initialize();

            shopScreen.OnItemClick += OnBuildClick;

            backButton.onClick.AddListener(BackToMain);
            backButton.gameObject.SetActive(false);
        }

        private void OnBuildClick(BuildItem item)
        {
            shopScreen.Hide();
            backButton.gameObject.SetActive(true);
        }

        private void BackToMain()
        {
            backButton.gameObject.SetActive(false);

        }
    }
}