using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraReader : MonoBehaviour
{
    private bool camAvaible;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public RawImage cubeGrid;

    ReadCubeCubeMap readCubeCubeMap;

    Vector3 cubeGridPos;


    private void Start()
    {
        readCubeCubeMap = FindObjectOfType<ReadCubeCubeMap>();

        cubeGridPos = cubeGrid.transform.position; // itt ez a grid bal also sarkat adja vissza, tehat ehhez meg majd hozza kell adni
        
        //ez igy a bal also kocka kozepe

        // Galaxy A22-n nem kell eltolni
        //cubeGridPos.x += 0;

        // WINDOWSON kell 110 offset
        cubeGridPos.x += 110;
        cubeGridPos.y += 110;

        Debug.Log("grid x " + cubeGridPos.x);
        Debug.Log("grid y " + cubeGridPos.y);


        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera avaible");
            camAvaible = false;
            return;
        }

        //itt a kamera kepenek merete
        //        backCam = new WebCamTexture(devices[0].name, 800, 768);
        //backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
        //backCam = new WebCamTexture(devices[0].name, devices[0].availableResolutions.width, devices[0].availableResolutions.height);
        //backCam = new WebCamTexture(devices[0].name, 2400, 1080);
        backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);


        backCam.Play();
        background.texture = backCam;

        background.SetNativeSize();
       // background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);


        camAvaible = true;

    }

    private void Update()
    {
        if (!camAvaible)
        {
            return;
        }


        //float ratio = (float)backCam.width / (float)backCam.height;
        //fit.aspectRatio = ratio;


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log("mouse position x " + mousePos.x);
                Debug.Log("mouse position y " + mousePos.y);
            }
        }
    }

    public void ReadFrontFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.front, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadBackFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.back, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadUpFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.up, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadDownFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.down, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadRightFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.right, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadLeftFace()
    {
        readCubeCubeMap.UpdateMap3(readCubeCubeMap.left, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    private int[] ReadColorFromSide(int x, int y)
    {
        snap = new Texture2D(backCam.width, backCam.height);
        snap.SetPixels(backCam.GetPixels());
        snap.Apply();

        int[] xOffsets = {0, 200, 400, 0, 200, 400, 0, 200, 400 };
        int[] yOffsets = {400, 400, 400, 200, 200, 200, 0, 0, 0};

        int[] colorIndexOfSide = new int[9];

        for(int i=0; i<9; ++i)
        {
            colorIndexOfSide[i] = ReadColorFromCoordinatesHSVDebugModeON(x + xOffsets[i], y + yOffsets[i]);
        }

        return colorIndexOfSide;
    }

    //------------ HSV COLOR FUCKERY
    public struct HSVColor
    {
        public float H;
        public float S;
        public float V;
    }
    

    Texture2D snap;

    public short[,] InRange(HSVColor[,] input, HSVColor upperTreshold, HSVColor lowerTreshold)
    {
        short[,] output = new short[50, 50];

        for (int i = 0; i < 50; ++i)
        {
            for (int j = 0; j < 50; j++)
            {
                if (input[i, j].H > 1 || input[i, j].S > 1 || input[i, j].V > 1 || input[i, j].H < 0 || input[i, j].S < 0 || input[i, j].V < 0)
                {
                    Debug.Log("HSV InRange ERROR!");
                    Debug.Assert(true);
                }

                output[i, j] = 0;

                if (input[i,j].H <= upperTreshold.H && input[i,j].H >= lowerTreshold.H)
                {
                    if (input[i, j].S <= upperTreshold.S && input[i, j].S >= lowerTreshold.S)
                    {
                        if (input[i, j].V <= upperTreshold.V && input[i, j].V >= lowerTreshold.V)
                        {
                            output[i, j] = 1;
                        }
                    }
                }
            }
        }

        return output;
    }

    public HSVColor[,] HSVtoPercentileHSV(HSVColor[,] input)
    {
        HSVColor[,] output = input;
        for (int i = 0; i < 50; ++i)
        {
            for(int j = 0; j < 50; ++j)
            {
                output[i, j].H = input[i, j].H / 359f;
                output[i, j].S = input[i, j].S / 100f;
                output[i, j].V = input[i, j].V / 100f;
            }
        }

        return output;
    }

    public HSVColor HSVtoPercentileHSV(HSVColor input)
    {
        HSVColor output = input;
        output.H = input.H / 360f;
        output.S = input.S / 100f;
        output.V = input.V / 100f;

        return output;
    }

    private int ReadColorFromCoordinatesHSV(int Coordx, int Coordy)
    {
        /*
    Color[] cubeColorsArray = new Color[] { Color.red, Color.green, Color.blue, new Color(1, 0.5f, 0, 1), Color.white, Color.yellow};
         * 
            red - 0
            green - 1
            blue - 2
            orange - 3
            white - 4
            yellow - 5
        */

        Color cubeGridPixelColor;
        HSVColor[,] HSVFromImage = new HSVColor[50, 50];
        short[,] outputFromInRange = new short[50, 50];

        // green treshhold
        HSVColor upperTresholdGreen;
        upperTresholdGreen.H = 185;
        upperTresholdGreen.S = 100;
        upperTresholdGreen.V = 100;
        upperTresholdGreen = HSVtoPercentileHSV(upperTresholdGreen);

        HSVColor lowerTresholdGreen;
        lowerTresholdGreen.H = 90;
        lowerTresholdGreen.S = 50;
        lowerTresholdGreen.V = 15;
        lowerTresholdGreen = HSVtoPercentileHSV(lowerTresholdGreen);

        // orange treshhold
        HSVColor upperTresholdOrange;
        upperTresholdOrange.H = 40;
        upperTresholdOrange.S = 100;
        upperTresholdOrange.V = 100;
        upperTresholdOrange = HSVtoPercentileHSV(upperTresholdOrange);

        HSVColor lowerTresholdOrange;
        lowerTresholdOrange.H = 10;
        lowerTresholdOrange.S = 50;
        lowerTresholdOrange.V = 15;
        lowerTresholdOrange = HSVtoPercentileHSV(lowerTresholdOrange);

        // red treshhold
        HSVColor upperTresholdRed;
        upperTresholdRed.H = 360;
        upperTresholdRed.S = 100;
        upperTresholdRed.V = 100;
        upperTresholdRed = HSVtoPercentileHSV(upperTresholdRed);

        HSVColor lowerTresholdRed;
        lowerTresholdRed.H = 345;
        lowerTresholdRed.S = 50;
        lowerTresholdRed.V = 10;
        lowerTresholdRed = HSVtoPercentileHSV(lowerTresholdRed);
        
        // red treshhold 2
        HSVColor upperTresholdRed2;
        upperTresholdRed2.H = 10;
        upperTresholdRed2.S = 100;
        upperTresholdRed2.V = 100;
        upperTresholdRed2 = HSVtoPercentileHSV(upperTresholdRed2);

        HSVColor lowerTresholdRed2;
        lowerTresholdRed2.H = 0;
        lowerTresholdRed2.S = 50;
        lowerTresholdRed2.V = 10;
        lowerTresholdRed2 = HSVtoPercentileHSV(lowerTresholdRed2);

        // blue treshhold
        HSVColor upperTresholdBlue;
        upperTresholdBlue.H = 300;
        upperTresholdBlue.S = 100;
        upperTresholdBlue.V = 100;
        upperTresholdBlue = HSVtoPercentileHSV(upperTresholdBlue);

        HSVColor lowerTresholdBlue;
        lowerTresholdBlue.H = 180;
        lowerTresholdBlue.S = 50;
        lowerTresholdBlue.V = 26;
        lowerTresholdBlue = HSVtoPercentileHSV(lowerTresholdBlue);

        // white treshhold
        HSVColor upperTresholdWhite;
        upperTresholdWhite.H = 360;
        upperTresholdWhite.S = 45;
        upperTresholdWhite.V = 100;
        upperTresholdWhite = HSVtoPercentileHSV(upperTresholdWhite);

        HSVColor lowerTresholdWhite;
        lowerTresholdWhite.H = 0;
        lowerTresholdWhite.S = 0;
        lowerTresholdWhite.V = 40;
        lowerTresholdWhite = HSVtoPercentileHSV(lowerTresholdWhite);

        // yellow treshhold
        HSVColor upperTresholdYellow;
        upperTresholdYellow.H = 85;
        upperTresholdYellow.S = 100;
        upperTresholdYellow.V = 100;
        upperTresholdYellow = HSVtoPercentileHSV(upperTresholdYellow);

        HSVColor lowerTresholdYellow;
        lowerTresholdYellow.H = 40;
        lowerTresholdYellow.S = 50;
        lowerTresholdYellow.V = 15;
        lowerTresholdYellow = HSVtoPercentileHSV(lowerTresholdYellow);

        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                cubeGridPixelColor = snap.GetPixel(Coordx + x*2, Coordy + y*2);
                Color.RGBToHSV(cubeGridPixelColor, out HSVFromImage[x + 25, y + 25].H, out HSVFromImage[x + 25, y + 25].S, out HSVFromImage[x + 25, y + 25].V);
                //snap.SetPixel(Coordx + x, Coordy + y, Color.red);
            }
        }

        // this will be counting each time a detection is found, if it hits a given percentile, we return a color
        int foundColor = 0;

        // green detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdGreen, lowerTresholdGreen);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if(outputFromInRange[x+25,y+25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.green);
                    ++foundColor;
                }
            }
        }

        // if we had foudn a color more than X times, we can return it confidentally
        if (foundColor > 180)
            return 1;
        else
            foundColor = 0;

        // orange detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdOrange, lowerTresholdOrange);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.magenta);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 3;
        else
            foundColor = 0;

        // red detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdRed, lowerTresholdRed);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.red);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 0;
        else
            foundColor = 0;

        // red2 detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdRed2, lowerTresholdRed2);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.red);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 0;
        else
            foundColor = 0;

        // blue detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdBlue, lowerTresholdBlue);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.blue);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 2;
        else
            foundColor = 0;

        // white detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdWhite, lowerTresholdWhite);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.white);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 4;
        else
            foundColor = 0;

        // yellow detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdYellow, lowerTresholdYellow);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    //snap.SetPixel(Coordx + x, Coordy + y, Color.yellow);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            return 5;
        else
            foundColor = 0;

        //snap.Apply();
        //background.texture = snap;

        return 0;
    }

    private int ReadColorFromCoordinatesHSVDebugModeON(int Coordx, int Coordy)
    {
        /*
            red - 0
            green - 1
            blue - 2
            orange - 3
            white - 4
            yellow - 5
        */

        //Texture2D snap = new Texture2D(backCam.width, backCam.height);
        //snap.SetPixels(backCam.GetPixels());//debug kedveert
        //snap.Apply();

        Color cubeGridPixelColor;
        HSVColor[,] HSVFromImage = new HSVColor[50, 50];
        short[,] outputFromInRange = new short[50, 50];

       // green treshhold
        HSVColor upperTresholdGreen;
        upperTresholdGreen.H = 185;
        upperTresholdGreen.S = 100;
        upperTresholdGreen.V = 100;
        upperTresholdGreen = HSVtoPercentileHSV(upperTresholdGreen);

        HSVColor lowerTresholdGreen;
        lowerTresholdGreen.H = 90;
        lowerTresholdGreen.S = 50;
        lowerTresholdGreen.V = 15;
        lowerTresholdGreen = HSVtoPercentileHSV(lowerTresholdGreen);

        // orange treshhold
        HSVColor upperTresholdOrange;
        upperTresholdOrange.H = 40;
        upperTresholdOrange.S = 100;
        upperTresholdOrange.V = 100;
        upperTresholdOrange = HSVtoPercentileHSV(upperTresholdOrange);

        HSVColor lowerTresholdOrange;
        lowerTresholdOrange.H = 10;
        lowerTresholdOrange.S = 50;
        lowerTresholdOrange.V = 15;
        lowerTresholdOrange = HSVtoPercentileHSV(lowerTresholdOrange);

        // red treshhold
        HSVColor upperTresholdRed;
        upperTresholdRed.H = 360;
        upperTresholdRed.S = 100;
        upperTresholdRed.V = 100;
        upperTresholdRed = HSVtoPercentileHSV(upperTresholdRed);

        HSVColor lowerTresholdRed;
        lowerTresholdRed.H = 345;
        lowerTresholdRed.S = 50;
        lowerTresholdRed.V = 10;
        lowerTresholdRed = HSVtoPercentileHSV(lowerTresholdRed);
        
        // red treshhold 2
        HSVColor upperTresholdRed2;
        upperTresholdRed2.H = 10;
        upperTresholdRed2.S = 100;
        upperTresholdRed2.V = 100;
        upperTresholdRed2 = HSVtoPercentileHSV(upperTresholdRed2);

        HSVColor lowerTresholdRed2;
        lowerTresholdRed2.H = 0;
        lowerTresholdRed2.S = 50;
        lowerTresholdRed2.V = 10;
        lowerTresholdRed2 = HSVtoPercentileHSV(lowerTresholdRed2);

        // blue treshhold
        HSVColor upperTresholdBlue;
        upperTresholdBlue.H = 300;
        upperTresholdBlue.S = 100;
        upperTresholdBlue.V = 100;
        upperTresholdBlue = HSVtoPercentileHSV(upperTresholdBlue);

        HSVColor lowerTresholdBlue;
        lowerTresholdBlue.H = 180;
        lowerTresholdBlue.S = 50;
        lowerTresholdBlue.V = 26;
        lowerTresholdBlue = HSVtoPercentileHSV(lowerTresholdBlue);

        // white treshhold
        HSVColor upperTresholdWhite;
        upperTresholdWhite.H = 360;
        upperTresholdWhite.S = 45;
        upperTresholdWhite.V = 100;
        upperTresholdWhite = HSVtoPercentileHSV(upperTresholdWhite);

        HSVColor lowerTresholdWhite;
        lowerTresholdWhite.H = 0;
        lowerTresholdWhite.S = 0;
        lowerTresholdWhite.V = 40;
        lowerTresholdWhite = HSVtoPercentileHSV(lowerTresholdWhite);

        // yellow treshhold
        HSVColor upperTresholdYellow;
        upperTresholdYellow.H = 85;
        upperTresholdYellow.S = 100;
        upperTresholdYellow.V = 100;
        upperTresholdYellow = HSVtoPercentileHSV(upperTresholdYellow);

        HSVColor lowerTresholdYellow;
        lowerTresholdYellow.H = 40;
        lowerTresholdYellow.S = 50;
        lowerTresholdYellow.V = 15;
        lowerTresholdYellow = HSVtoPercentileHSV(lowerTresholdYellow);

        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                cubeGridPixelColor = snap.GetPixel(Coordx + x*2, Coordy + y*2);
                Color.RGBToHSV(cubeGridPixelColor, out HSVFromImage[x + 25, y + 25].H, out HSVFromImage[x + 25, y + 25].S, out HSVFromImage[x + 25, y + 25].V);
                snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.red);
            }
        }

        // this will be counting each time a detection is found, if it hits a given percentile, we return a color
        int foundColor = 0;

        int colorIndexToReturn = 0;

        // green detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdGreen, lowerTresholdGreen);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.green);
                    ++foundColor;
                }
            }
        }

        // if we had foudn a color more than X times, we can return it confidentally
        if (foundColor > 180)
            colorIndexToReturn = 1;
        else
            foundColor = 0;

        // orange detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdOrange, lowerTresholdOrange);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.magenta);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 3;
        else
            foundColor = 0;

        // red detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdRed, lowerTresholdRed);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.red);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 0;
        else
            foundColor = 0;

        // red2 detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdRed2, lowerTresholdRed2);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.red);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 0;
        else
            foundColor = 0;

        // blue detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdBlue, lowerTresholdBlue);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.blue);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 2;
        else
            foundColor = 0;

        // white detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdWhite, lowerTresholdWhite);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.white);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 4;
        else
            foundColor = 0;

        // yellow detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdYellow, lowerTresholdYellow);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x*2, Coordy + y*2, Color.yellow);
                    ++foundColor;
                }
            }
        }

        if (foundColor > 180)
            colorIndexToReturn = 5;
        else
            foundColor = 0;

        snap.Apply();
        background.texture = snap;

        return colorIndexToReturn;
    }

    //---------------------
    public void StopCameraPlaying()
    {
        backCam.Stop();
    }
}
