using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        StartCoroutine(StartGame());    
    }

    private IEnumerator StartGame()
    {
        AudioManager.Instance.PlayAudioint(8);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainLevel1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
