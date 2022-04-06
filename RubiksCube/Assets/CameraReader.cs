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


    //teszt kocka amire kiteszem a szint
    public RawImage colorCube;



    private void Start()
    {
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





            Color clickedColor = backCam.GetPixel((int)mousePos.x, (int)mousePos.y);

            //egy kocka formaban kiszedni pixelek szinet es atlagolni

            float r = 0;
            float g = 0;
            float b = 0;

            float cnt = 0;

            Color nearClickedColor = backCam.GetPixel((int)mousePos.x + 1, (int)mousePos.y + 1);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x - 1, (int)mousePos.y - 1);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x - 1, (int)mousePos.y + 1);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x + 1, (int)mousePos.y - 1);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x, (int)mousePos.y);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x - 10, (int)mousePos.y - 10);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x - 10, (int)mousePos.y + 10);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x + 10, (int)mousePos.y - 10);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            nearClickedColor = backCam.GetPixel((int)mousePos.x + 10, (int)mousePos.y + 10);

            r += nearClickedColor.r;
            g += nearClickedColor.g;
            b += nearClickedColor.b;
            ++cnt;

            Color avarageColor = new Color(r / cnt, g / cnt, b / cnt);
            colorCube.color = avarageColor;

            //-------

            //colorCube.color = clickedColor;

        }
    }

    public void StopCameraPlaying()
    {
        backCam.Stop();
    }
}
