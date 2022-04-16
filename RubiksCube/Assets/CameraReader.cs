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



    private void Start()
    {
        readCubeCubeMap = FindObjectOfType<ReadCubeCubeMap>();

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


        float ratio = (float)backCam.width / (float)backCam.height;
        //fit.aspectRatio = ratio;


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log("mouse position x " + mousePos.x);
                Debug.Log("mouse position y " + mousePos.y);
            }

            Vector3 cubeGridPos = cubeGrid.transform.position; // itt ez a grid bal also sarkat adja vissza, tehat ehhez meg majd hozza kell adni

            //ez igy a bal also kocka kozepe
            cubeGridPos.x += 55;
            cubeGridPos.y += 55;
            Debug.Log("grid x " + cubeGridPos.x);
            Debug.Log("grid y " + cubeGridPos.y);

            readCubeCubeMap.UpdateMap( readCubeCubeMap.front, ReadColorFromSide( (int)cubeGridPos.x, (int)cubeGridPos.y));
            readCubeCubeMap.UpdateMap(readCubeCubeMap.back, ReadColorFromSide((int)cubeGridPos.x, (int)cubeGridPos.y));


        }
    }

    private Color[] ReadColorFromSide(int x, int y)
    {
        int[] xOffsets = {0, 100, 200, 0, 100, 200, 0, 100, 200};
        int[] yOffsets = {200, 200, 200, 100, 100, 100, 0, 0, 0};

        Color[] colorsOfSide = new Color[9];

        for(int i=0; i<9; ++i)
        {
            colorsOfSide[i] = ReadColorFromCoordinates(x + xOffsets[i], y + yOffsets[i]);
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

        int[] pixelCoordinateOffsets = new int[] { -10, -5, 5, 10 };

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

        Color avarageColor = new Color(r / cnt, g / cnt, b / cnt);

        return avarageColor;
        //readCubeCubeMap.UpdateMap(avarageColor);
    }

    public void StopCameraPlaying()
    {
        backCam.Stop();
    }
}
