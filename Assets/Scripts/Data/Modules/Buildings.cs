using Data.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Buildings
    {
        public BuildItem[] BuildingModels { get; private set; }

        public BuildItem CurrentBuild { get; private set; }
        public DateTime WhenStartedBuild { get; private set; }

        public void Initialize()
        {

        }

        private void LoadModelsData()
        {

        }
    }
}
