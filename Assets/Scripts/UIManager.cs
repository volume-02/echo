using TMPro;
using UnityEngine;

namespace Ghostery
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI hpText;
        public TextMeshProUGUI scoreText;
        public PlayerScript player;

        void Update()
        {
            hpText.text = $"HP: {player.health}";
            scoreText.text = $"Score: {player.score}";
        }
    }
}
