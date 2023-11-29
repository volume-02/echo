using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ghostery;
using UnityEngine.Events;

namespace Ghostery
{
    public class GameManager : MonoBehaviour
    {

        public bool isGameOver = false;
        public Vector3 savePos;

        [SerializeField] TextMeshProUGUI gameOverText;
        [SerializeField] Button restartButton;
        [SerializeField] Button reviveButton;
        [SerializeField] GameObject player;
        [SerializeField] Button mainMenuButton;
        [SerializeField] TextMeshProUGUI winText;
        public UnityEvent onGameOver;

        public void GameOver()
        {
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            reviveButton.gameObject.SetActive(true);
            player.SetActive(false);
            onGameOver?.Invoke();
        }

        public void GameOverSuccusessfully()
        {
            isGameOver = true;
            restartButton.gameObject.SetActive(true);
            player.SetActive(false);
            winText.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OpenMainMenu() {
            SceneManager.LoadScene("MainMenu");
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
