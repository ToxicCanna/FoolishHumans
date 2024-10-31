using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] private float waitSeconds; 
    IEnumerator WaitAndReturn(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        StartCoroutine(WaitAndReturn(waitSeconds));
    }
}
