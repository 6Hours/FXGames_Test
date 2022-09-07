using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private Material normalStateMaterial;
        [SerializeField] private Material buildStateMaterial;

        public System.Action OnBuildingFinished;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
