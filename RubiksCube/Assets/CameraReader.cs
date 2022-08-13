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
        cubeGridPos.x += 55;
        cubeGridPos.y += 55;
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
        backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);


        backCam.Play();
        background.texture = backCam;

        background.SetNativeSize();


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
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.front, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadBackFace()
    {
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.back, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadUpFace()
    {
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.up, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadDownFace()
    {
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.down, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadRightFace()
    {
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.right, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    public void ReadLeftFace()
    {
        readCubeCubeMap.UpdateMap2(readCubeCubeMap.left, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));
    }

    private Color[] ReadColorFromSide(int x, int y)
    {
        snap = new Texture2D(backCam.width, backCam.height);
        snap.SetPixels(backCam.GetPixels());
        snap.Apply();

        int[] xOffsets = {0, 100, 200, 0, 100, 200, 0, 100, 200};
        int[] yOffsets = {200, 200, 200, 100, 100, 100, 0, 0, 0};

        Color[] colorsOfSide = new Color[9];

        for(int i=0; i<9; ++i)
        {
            colorsOfSide[i] = ReadColorFromCoordinates(x + xOffsets[i], y + yOffsets[i]);
            ReadColorFromCoordinatesHSV(x + xOffsets[i], y + yOffsets[i]);
        }

        return colorsOfSide;
    }

    private Color ReadColorFromCoordinates(int Coordx, int Coordy)
    {
        //egy kocka formaban kiszedni pixelek szinet es atlagolni
        float r = 0;
        float g = 0;
        float b = 0;

        float cnt = 0;

        //-------
        // 50x50 es gridbol atlagolok
        Color cubeGridMiddleColor;

        for (int x = -25; x <= 25; ++x)
        {
            for (int y = -25; y <= 25; ++y)
            {
                cubeGridMiddleColor = backCam.GetPixel(Coordx + x, Coordy + y);

                r += cubeGridMiddleColor.r;
                g += cubeGridMiddleColor.g;
                b += cubeGridMiddleColor.b;
                ++cnt;
            }
        }
        //---------


        /*
        // fix szamu offsetes megoldas
        int[] pixelCoordinateOffsets = new int[] { -15, -10, -5, 5, 10, 15};

        Color cubeGridMiddleColor;

        foreach (int x in pixelCoordinateOffsets)
        {
            foreach (int y in pixelCoordinateOffsets)
            {
                cubeGridMiddleColor = backCam.GetPixel(Coordx + x, Coordy + y);

                r += cubeGridMiddleColor.r;
                g += cubeGridMiddleColor.g;
                b += cubeGridMiddleColor.b;
                ++cnt;
            }
        }
        */

        Color avarageColor = new Color(r / cnt, g / cnt, b / cnt);

        return avarageColor;
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
                if (input[i, j].H > 1 || input[i, j].S > 1 || input[i, j].V > 1)
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

    public void ReadColorFromCoordinatesHSV(int Coordx, int Coordy)
    {
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
        lowerTresholdRed.V = 26;
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
        lowerTresholdRed2.V = 26;
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
        lowerTresholdWhite.V = 50;
        lowerTresholdWhite = HSVtoPercentileHSV(lowerTresholdWhite);


        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                cubeGridPixelColor = snap.GetPixel(Coordx + x, Coordy + y);
                Color.RGBToHSV(cubeGridPixelColor, out HSVFromImage[x + 25, y + 25].H, out HSVFromImage[x + 25, y + 25].S, out HSVFromImage[x + 25, y + 25].V);
                //snap.SetPixel(Coordx + x, Coordy + y, Color.red);
            }
        }

        //Debug.Log("H: " + HSVFromImage[25, 25].H + " S: " + HSVFromImage[25, 25].S + " V: " + HSVFromImage[25, 25].V);

        // green detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdGreen, lowerTresholdGreen);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if(outputFromInRange[x+25,y+25] == 1)
                {
                    snap.SetPixel(Coordx + x, Coordy + y, Color.green);
                }
            }
        }

        // orange detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdOrange, lowerTresholdOrange);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x, Coordy + y, Color.magenta);
                }
            }
        }

        // red detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdRed, lowerTresholdRed);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x, Coordy + y, Color.red);
                }
            }
        }

        // blue detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdBlue, lowerTresholdBlue);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x, Coordy + y, Color.blue);
                }
            }
        }

        // white detection
        outputFromInRange = InRange(HSVFromImage, upperTresholdWhite, lowerTresholdWhite);
        for (int x = -25; x < 25; ++x)
        {
            for (int y = -25; y < 25; ++y)
            {
                if (outputFromInRange[x + 25, y + 25] == 1)
                {
                    snap.SetPixel(Coordx + x, Coordy + y, Color.white);
                }
            }
        }

        snap.Apply();
        background.texture = snap;

    }


    //---------------------
    public void StopCameraPlaying()
    {
        backCam.Stop();
    }
}
