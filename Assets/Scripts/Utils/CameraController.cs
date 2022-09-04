using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class CameraController : MonoBehaviour
    {
        [System.Serializable]
        public struct Range
        {
            public float Min;
            public float Max;
        }

        [SerializeField] private Range xRange;
        [SerializeField] private Range zRange;
        [SerializeField] private float moveSpeed = 1f;

        // Update is called once per frame
        void Update()
        {
            float XVelocity = 0f;
            float ZVelocity = 0f;
#if UNITY_EDITOR
            XVelocity = Input.GetAxis("Horizontal");
            ZVelocity = Input.GetAxis("Vertical");
#endif

            transform.Translate(new Vector3(XVelocity, 0f, ZVelocity) * Time.deltaTime * moveSpeed);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, xRange.Min, xRange.Max),
                transform.position.y,
                Mathf.Clamp(transform.position.z, zRange.Min, zRange.Max));
        }
    }
}
