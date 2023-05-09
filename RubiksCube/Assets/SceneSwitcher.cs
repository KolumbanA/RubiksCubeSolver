using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject solveButton;
    public GameObject randomizeButton;
    public GameObject algorithmsButton;
    public GameObject algorithmsSelectButton;
    public GameObject algorithmsNextButton;
    public GameObject algorithmsPreviousButton;

    private bool algorithmsViewActive = false;

    private void Start()
    {
        algorithmsViewActive = false;
        randomizeButton.SetActive(true);
        solveButton.SetActive(true);
        algorithmsSelectButton.SetActive(false);
        algorithmsNextButton.SetActive(false);
        algorithmsPreviousButton.SetActive(false);
    }
    public void CubeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ReadCubeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SwitchToAlgorithmsView()
    {
        if(algorithmsViewActive) {
            algorithmsViewActive = false;
            randomizeButton.SetActive(true);
            solveButton.SetActive(true);
            algorithmsSelectButton.SetActive(false);
            algorithmsNextButton.SetActive(false);
            algorithmsPreviousButton.SetActive(false);
        } else {
            algorithmsViewActive = true;
            randomizeButton.SetActive(false);
            solveButton.SetActive(false);
            algorithmsSelectButton.SetActive(true);
            algorithmsNextButton.SetActive(true);
            algorithmsPreviousButton.SetActive(true);
        }
    }
}
