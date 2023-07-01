using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolvingAlgorithms : MonoBehaviour
{
    public GameObject solveButton;
    public GameObject randomizeButton;
    public GameObject algorithmsButton;
    public GameObject algorithmsSelectButton;
    public GameObject algorithmsNextButton;
    public GameObject algorithmsPreviousButton;

    private bool algorithmsViewActive = false;
    public Text algorithmsSelectButtonText;
    private int selectedAlgorithmIndex = 0;

    /*
     { "U", "D", "L", "R", "F", "B",
      "U'", "D'", "L'", "R'", "F'", "B'",
      "U2", "D2", "L2", "R2", "F2", "B2"};
    */

    private readonly List<string> topLayerSwitchFrontCorners = new List<string>
    { "R'", "F", "R'", "B", "B", "R", "F'", "R'", "B", "B", "R", "R", "U"};

    private readonly List<string> lastLayerCorners = new List<string>
    { "R", "U", "R'", "U", "R", "U", "U", "R'"};

    private readonly List<string> secondLayerSideOfT = new List<string>
    { "U", "R", "U'", "R'", "U'", "F'", "U", "F"};
     
    private readonly List<string> lToCross = new List<string>
    { "F", "U", "R", "U'", "R'", "F'"};


    private readonly List<string> solvingAlgorithms = new List<string>
    {"topLayerSwitchFrontCorners", "lastLayerCorners", "lToCross", "secondLayerSideOfT"};

    // Start is called before the first frame update
    void Start()
    {
        algorithmsSelectButtonText.text = solvingAlgorithms[0].ToString();
        algorithmsViewActive = false;
        randomizeButton.SetActive(true);
        solveButton.SetActive(true);
        algorithmsSelectButton.SetActive(false);
        algorithmsNextButton.SetActive(false);
        algorithmsPreviousButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestAlgorithm()
    {
        switch(selectedAlgorithmIndex)
        {
            case 0:
                AutoRotation.moveList = new List<string>(topLayerSwitchFrontCorners);
                break;
            case 1:
                AutoRotation.moveList = new List<string>(lastLayerCorners);
                break;
            case 2:
                AutoRotation.moveList = new List<string>(lToCross);
                break;
            case 3:
                AutoRotation.moveList = new List<string>(secondLayerSideOfT);
                break;
            default:
                break;
        }
    }

    public void NextAlgorithmButtonClicked()
    {
        if(selectedAlgorithmIndex < solvingAlgorithms.Count - 1)
        {
            ++selectedAlgorithmIndex;
        } else
        {
            selectedAlgorithmIndex = 0;
        }
        algorithmsSelectButtonText.text = solvingAlgorithms[selectedAlgorithmIndex].ToString();
    }

    public void PreviousAlgorithmButtonClicked()
    {
        if (selectedAlgorithmIndex > 0)
        {
            --selectedAlgorithmIndex;
        }
        else
        {
            selectedAlgorithmIndex = solvingAlgorithms.Count - 1;
        }
        algorithmsSelectButtonText.text = solvingAlgorithms[selectedAlgorithmIndex].ToString();
    }
    public void SwitchToAlgorithmsView()
    {
        if (algorithmsViewActive)
        {
            algorithmsViewActive = false;
            randomizeButton.SetActive(true);
            solveButton.SetActive(true);
            algorithmsSelectButton.SetActive(false);
            algorithmsNextButton.SetActive(false);
            algorithmsPreviousButton.SetActive(false);
        }
        else
        {
            algorithmsViewActive = true;
            randomizeButton.SetActive(false);
            solveButton.SetActive(false);
            algorithmsSelectButton.SetActive(true);
            algorithmsNextButton.SetActive(true);
            algorithmsPreviousButton.SetActive(true);
        }
    }
}
