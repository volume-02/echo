using TMPro;
using UnityEngine;

namespace Ghostery
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI hpText;
        public PlayerScript player;

        void Update()
        {
            hpText.text = $"HP: {player.health}";
        }
    }
}
