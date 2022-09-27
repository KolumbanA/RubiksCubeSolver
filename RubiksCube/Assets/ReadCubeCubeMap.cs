using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
        UpdateCubeColorsArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCubeColorsArray()
    {
        // ez a 6 szin amit kintrol huzok be prefabbol
        cubeColorsArray[0] = cubeRedColor.color;
        cubeColorsArray[1] = cubeGreenColor.color;
        cubeColorsArray[2] = cubeBlueColor.color;
        cubeColorsArray[3] = cubeOrangeColor.color;
        cubeColorsArray[4] = cubeWhiteColor.color;
        cubeColorsArray[5] = cubeYellowColor.color;

    }

    private float SmartColorDifference(Color color1, Color color2)
    {
        float rmean = ((float)color1.r + (float)color2.r) / 2;
        float r = (float)color1.r - (float)color2.r;
        float g = (float)color1.g - (float)color2.g;
        float b = (float)color1.b - (float)color2.b;

        return Mathf.Sqrt((((512 + rmean) * r * r)/(Mathf.Pow(2,8))) + 4 * g * g + (((767 - rmean) * b * b)/(Mathf.Pow(2, 8))));
    }

    private float ColorDifference(Color color1, Color color2)
    {
        return (Mathf.Abs(color1.r - color2.r) + Mathf.Abs(color1.g - color2.g) + Mathf.Abs(color1.b - color2.b)) / 3;
    }

    private Color MatchColorToCubeColor(Color color)
    {
        double minDifference = SmartColorDifference(color, cubeColorsArray[0]);
        double difference;
        int minDifferenceIndex = 0;

        for(int i = 0; i < 6; ++i)
        {
            difference = SmartColorDifference(color, cubeColorsArray[i]);
            if (difference < minDifference)
            {
                minDifference = difference;
                minDifferenceIndex = i;
                //Debug.Log(i);
            }


        }

        return cubeColorsArray[minDifferenceIndex];
    }


    private Color MatchColorToCubeColorByIndex(int colorIndex)
    {
        if (colorIndex == 1)
            return cubeColorsArray[0];
        if(colorIndex == 2)
            return cubeColorsArray[1];
        if(colorIndex == 3)
            return cubeColorsArray[2];
        if(colorIndex == 4)
            return cubeColorsArray[5];
        if(colorIndex == 5)
            return cubeColorsArray[3];
        if(colorIndex == 6)
            return cubeColorsArray[4];

        return cubeColorsArray[0];
    }

    public void UpdateMap2(Transform side, Color[] color)
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

    public void UpdateMap3(Transform side, int[] colorIndex)
    {

        side.GetChild(0).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[0]);
        side.GetChild(1).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[1]);
        side.GetChild(2).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[2]);
        side.GetChild(3).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[3]);
        side.GetChild(4).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[4]);
        side.GetChild(5).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[5]);
        side.GetChild(6).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[6]);
        side.GetChild(7).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[7]);
        side.GetChild(8).GetComponent<Image>().color = MatchColorToCubeColorByIndex(colorIndex[8]);

    }
}
