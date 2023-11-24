using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }

    public void OpenTelegram()
    {
        Application.OpenURL("https://t.me/plaaaaan_b");
    }
}
