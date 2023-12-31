using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ghostery
{
    public class UIManager : MonoBehaviour
    {
        public PlayerScript player;
        [SerializeField] GameObject hpPrefab;
        [SerializeField] GameObject hudContainer;

        int maxHp = 4;
        List<GameObject> hpList = new List<GameObject>();

        private void Start()
        {
            for (int i = 0; i < maxHp; i++)
            {
                var instObject = Instantiate(hpPrefab);
                hpList.Add(instObject);
                instObject.transform.SetParent(hudContainer.transform, false);
                instObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-215 + 250 * i, 68, 0);
            }
        }

        void Update()
        {
            for (int i = 0; i < hpList.Count; i++)
            {
                if (i < player.health)
                {
                    hpList[i].SetActive(true);
                }
                else
                {
                    hpList[i].SetActive(false);
                }
            }
        }

    }
}
