using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class DelayService : Singleton<DelayService>
    {
        private List<(DateTime d, Func<int> f)> list = new List<(DateTime d, Func<int>)>();
        public void AddCallback(DateTime invokeTime, Func<int> func)
        {
            list.Add((invokeTime, func));
        }

        void Update()
        {
            foreach(var item in list)
            {
                if(item.d < DateTime.UtcNow)
                {
                    item.f();
                    list.Remove(item);
                }
            }
        }
    }
}
