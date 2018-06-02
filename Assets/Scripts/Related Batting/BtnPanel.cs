using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Related_Batting
{
    public class BtnPanel : MonoBehaviour
    {
        public new RectTransform transform;

        private void Awake()
        {
            transform = GetComponent<RectTransform>();
        }
    }
}
