using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ghostery;

namespace Ghostery
{
    public class GameManager : MonoBehaviour
    {

        public bool isGameOver = false;
        public TextMeshProUGUI gameOverText;
        public Button restartButton;
        public Button reviveButton;
        public GameObject player;
        public Vector3 savePos;

        public void GameOver()
        {
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            reviveButton.gameObject.SetActive(true);
            player.SetActive(false);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Revive()
        {
            var playerScript = player.GetComponent<PlayerScript>();

            isGameOver = false;
            gameOverText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            reviveButton.gameObject.SetActive(false);

            playerScript.Heal(3);

            player.transform.position = savePos;
            player.SetActive(true);
        }

        public void StorePoint(Vector3 position)
        {
            savePos = position;
        }
    }
}
