using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public bool isGameOver;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button reviveButton;
    public GameObject player;
    new public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        reviveButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Revive()
    {
        var playerScript = player.GetComponent<PlayerScript>();
        var cameraScript = camera.GetComponent<CameraScript>();

        isGameOver = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        reviveButton.gameObject.SetActive(false);

        playerScript.Heal();

        player.transform.position = playerScript.savePos;

    }
}
