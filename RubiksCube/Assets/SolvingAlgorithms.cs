using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolvingAlgorithms : MonoBehaviour
{
    public Text algorithmsSelectButtonText;
    private int selectedAlgorithmIndex = 0;

    /*
     { "U", "D", "L", "R", "F", "B",
      "U'", "D'", "L'", "R'", "F'", "B'",
      "U2", "D2", "L2", "R2", "F2", "B2"};
    */

private readonly List<string> testAlgorithm = new List<string>
    { "U", "U", "U", "D"};

    private readonly List<string> testAlgorithm2 = new List<string>
    { "D", "D", "D", "D"};

    private readonly List<string> testAlgorithm3 = new List<string>
    { "L", "L", "L", "L"};

    private readonly List<string> testAlgorithm4 = new List<string>
    { "F", "F", "F", "F"};


    private readonly List<string> solvingAlgorithms = new List<string>
    { "Teszt1", "Teszt2", "Teszt3", "Teszt4"};

    // Start is called before the first frame update
    void Start()
    {
        algorithmsSelectButtonText.text = solvingAlgorithms[0].ToString();
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
                AutoRotation.moveList = new List<string>(testAlgorithm);
                break;
            case 1:
                AutoRotation.moveList = new List<string>(testAlgorithm2);
                break;
            case 2:
                AutoRotation.moveList = new List<string>(testAlgorithm3);
                break;
            case 3:
                AutoRotation.moveList = new List<string>(testAlgorithm4);
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

}
