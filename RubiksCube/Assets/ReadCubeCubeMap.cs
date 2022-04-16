using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCubeCubeMap : MonoBehaviour
{
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;


    public Material cubeRedColor;
    public Material cubeGreenColor;
    public Material cubeBlueColor;
    public Material cubeOrangeColor;
    public Material cubeWhiteColor;
    public Material cubeYellowColor;

    Color[] cubeColorsArray = new Color[] { Color.red, Color.green, Color.blue, new Color(1, 0.5f, 0, 1), Color.white, Color.yellow};

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCubeColorsArray()
    {
        cubeColorsArray[0] = cubeRedColor.color;
        cubeColorsArray[1] = cubeGreenColor.color;
        cubeColorsArray[2] = cubeBlueColor.color;
        cubeColorsArray[3] = cubeOrangeColor.color;
        cubeColorsArray[4] = cubeWhiteColor.color;
        cubeColorsArray[5] = cubeYellowColor.color;
    }

    private float ColorDifference(Color color1, Color color2)
    {
        return (Mathf.Abs(color1.r - color2.r) + Mathf.Abs(color1.g - color2.g) + Mathf.Abs(color1.b - color2.b)) / 3;
    }

    private Color MatchColorToCubeColor(Color color)
    {
        double minDifference = ColorDifference(color, cubeColorsArray[0]);
        double difference;
        int minDifferenceIndex = 0;

        for(int i = 0; i < 6; ++i)
        {
            difference = ColorDifference(color, cubeColorsArray[i]);
            if (difference < minDifference)
            {
                minDifference = difference;
                minDifferenceIndex = i;
            }
        }
        /*
        Debug.Log("yellowR" + Color.yellow.r);
        Debug.Log("yellowG" + Color.yellow.g);
        Debug.Log("yellowB" + Color.yellow.b);


        Debug.Log("orangeR" + cubeOrangeColor.r);
        Debug.Log("orangeG" + cubeOrangeColor.g);
        Debug.Log("orangeB" + cubeOrangeColor.b);
        */
        return cubeColorsArray[minDifferenceIndex];
    }

    public void UpdateMap(Transform side, Color[] color)
    {

        side.GetChild(0).GetComponent<Image>().color = MatchColorToCubeColor(color[0]);
        side.GetChild(1).GetComponent<Image>().color = MatchColorToCubeColor(color[1]);
        side.GetChild(2).GetComponent<Image>().color = MatchColorToCubeColor(color[2]);
        side.GetChild(3).GetComponent<Image>().color = MatchColorToCubeColor(color[3]);
        side.GetChild(4).GetComponent<Image>().color = MatchColorToCubeColor(color[4]);
        side.GetChild(5).GetComponent<Image>().color = MatchColorToCubeColor(color[5]);
        side.GetChild(6).GetComponent<Image>().color = MatchColorToCubeColor(color[6]);
        side.GetChild(7).GetComponent<Image>().color = MatchColorToCubeColor(color[7]);
        side.GetChild(8).GetComponent<Image>().color = MatchColorToCubeColor(color[8]);

    }
}
