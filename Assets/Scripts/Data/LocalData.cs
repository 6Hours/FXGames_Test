using Data.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class LocalData : MonoBehaviour
    {
        public static Currencies Currencies { get; private set; }
        public static Buildings Buildings { get; private set; }

        private Currencies currenciesModel = new Currencies();
        private Buildings buildingsModel = new Buildings();

        public void Awake()
        {
            Currencies = currenciesModel;
            Buildings = buildingsModel;

            currenciesModel.Initialize();
            buildingsModel.Initialize();
        }
    }
}