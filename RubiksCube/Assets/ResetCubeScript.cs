using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetCubeScript : MonoBehaviour
{
    Color[] cubeColorsArray = new Color[] { Color.red, Color.green, Color.blue, new Color(1, 0.5f, 0, 1), Color.white, Color.yellow };

    GameObject cubePiece1;
    GameObject cubePiece2;
    GameObject cubePiece3;
    GameObject cubePiece4;
    GameObject cubePiece5;
    GameObject cubePiece6;
    GameObject cubePiece7;
    GameObject cubePiece8;
    GameObject cubePiece9;
    GameObject cubePiece10;
    GameObject cubePiece11;
    GameObject cubePiece12;
    GameObject cubePiece13;
    GameObject cubePiece14;
    GameObject cubePiece15;
    GameObject cubePiece16;
    GameObject cubePiece17;
    GameObject cubePiece18;
    GameObject cubePiece19;
    GameObject cubePiece20;
    GameObject cubePiece21;
    GameObject cubePiece22;
    GameObject cubePiece23;
    GameObject cubePiece24;
    GameObject cubePiece25;
    GameObject cubePiece26;

    GameObject[] upCubes = new GameObject[9];

    public CubeSideReader cubeSideReader;
    public RubiksCubeMap rubiksCubeMap;
    public RotateWholeCube rotateWholeCube;
    public GameObject rubiksCubeTarget;
    public GameObject rubiksCube;
    void Start()
    {
        rotateWholeCube = FindObjectOfType<RotateWholeCube>();
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        rubiksCubeMap = FindObjectOfType<RubiksCubeMap>();
        rubiksCubeTarget = GameObject.Find("Target");
        rubiksCube = GameObject.Find("Target");

        cubePiece1 = GameObject.Find("L");
        cubePiece2 = GameObject.Find("R");
        cubePiece3 = GameObject.Find("Piece (3)");   // side piece
        cubePiece4 = GameObject.Find("B");
        cubePiece5 = GameObject.Find("Piece (5)");   // side piece
        cubePiece6 = GameObject.Find("D");
        cubePiece7 = GameObject.Find("Piece (7)");   // side piece
        cubePiece8 = GameObject.Find("Piece (8)");   // side piece
        cubePiece9 = GameObject.Find("Piece (9)");   // side piece
        cubePiece10 = GameObject.Find("Piece (10)"); //  side piece
        cubePiece11 = GameObject.Find("Piece (11)"); //  side piece
        cubePiece12 = GameObject.Find("U");
        cubePiece13 = GameObject.Find("Piece (13)"); //  side piece
        cubePiece14 = GameObject.Find("Piece (14)"); //  side piece
        cubePiece15 = GameObject.Find("Piece (15)"); //  side piece
        cubePiece16 = GameObject.Find("Piece (16)"); //  side piece
        cubePiece17 = GameObject.Find("Piece (17)"); //  side piece
        cubePiece18 = GameObject.Find("F");
        cubePiece19 = GameObject.Find("Piece (19)"); // side piece
        cubePiece20 = GameObject.Find("Piece (20)"); // side piece
        cubePiece21 = GameObject.Find("Piece (21)"); // side piece
        cubePiece22 = GameObject.Find("Piece (22)"); // side piece
        cubePiece23 = GameObject.Find("Piece (23)"); // side piece
        cubePiece24 = GameObject.Find("Piece (24)"); // side piece
        cubePiece25 = GameObject.Find("Piece (25)"); // side piece
        cubePiece26 = GameObject.Find("Piece (26)"); // side piece

        upCubes[0] = cubePiece25;
        upCubes[1] = cubePiece19;
        upCubes[2] = cubePiece23;
        upCubes[3] = cubePiece21;
        upCubes[4] = cubePiece12;
        upCubes[5] = cubePiece24;
        upCubes[6] = cubePiece26;
        upCubes[7] = cubePiece22;
        upCubes[8] = cubePiece20;
    }

    void Update()
    {
        
    }

    public void ResetCube()
    {
        rubiksCubeTarget.transform.eulerAngles = new Vector3(0, 0, 0);
        rotateWholeCube.RotateCubeInstantly();

        cubePiece1.transform.position = new Vector3(0, 0, 1);
        cubePiece2.transform.position = new Vector3(0, 0, -1);
        cubePiece3.transform.position = new Vector3(1, 0, -1);
        cubePiece4.transform.position = new Vector3(1, 0, 0);
        cubePiece5.transform.position = new Vector3(1, 0, 1);
        cubePiece6.transform.position = new Vector3(0, -1, 0);
        cubePiece7.transform.position = new Vector3(-1, 0, 1);
        cubePiece8.transform.position = new Vector3(-1, 0, -1);
        cubePiece9.transform.position = new Vector3(1, -1, 0);
        cubePiece10.transform.position = new Vector3(1, -1, 1);
        cubePiece11.transform.position = new Vector3(-1, -1, -1);
        cubePiece12.transform.position = new Vector3(0, 1, 0);
        cubePiece13.transform.position = new Vector3(0, -1, 1);
        cubePiece14.transform.position = new Vector3(0, -1, -1);
        cubePiece15.transform.position = new Vector3(1, -1, -1);
        cubePiece16.transform.position = new Vector3(-1, -1, 1);
        cubePiece17.transform.position = new Vector3(-1, -1, 0);
        cubePiece18.transform.position = new Vector3(-1, 0, 0);
        cubePiece19.transform.position = new Vector3(0, 1, 1);
        cubePiece20.transform.position = new Vector3(1, 1, -1);
        cubePiece21.transform.position = new Vector3(-1, 1, 0);
        cubePiece22.transform.position = new Vector3(0, 1, -1);
        cubePiece23.transform.position = new Vector3(1, 1, 1);
        cubePiece24.transform.position = new Vector3(1, 1, 0);
        cubePiece25.transform.position = new Vector3(-1, 1, 1);
        cubePiece26.transform.position = new Vector3(-1, 1, -1);


        cubePiece1.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece2.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece3.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece4.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece5.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece6.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece7.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece8.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece9.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece10.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece11.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece12.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece13.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece14.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece15.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece16.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece17.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece18.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece19.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece20.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece21.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece22.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece23.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece24.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece25.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;
        cubePiece26.transform.eulerAngles = rubiksCubeTarget.transform.eulerAngles;

        //Transform[] allChildren = this.GetComponentsInChildren<Transform>();


        foreach (GameObject piece in upCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            //Debug.Log("sizeof Children array: " + allChildren.Length);
            //Debug.Log(allChildren[0].name + "  -  " + allChildren[1].name + "  -  " + allChildren[2].name + "  -  " + allChildren[3].name + "  -  " + allChildren[4].name + "  -  " + allChildren[5].name + "  -  " + allChildren[6].name + "  -  ");
            //allChildren[0] az a parent object

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            // Color[] cubeColorsArray = new Color[] { Color.red, Color.green, Color.blue, new Color(1, 0.5f, 0, 1), Color.white, Color.yellow };

            Renderer renderer = allChildren[4].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[2];
        }

        cubeSideReader.ReadCubeState();
    }


    // A reset jol mukodesehez szukseges, hogy a kocka ne legyen elforgatva terben
    public void FillCube ()
    {
        //itt a kockak kis kockainak a neveit es szineit is kellene resetelni
        ResetCube();



        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 0)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[0];

                upCubes[i].transform.Find("Up").name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 1)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[1];

                upCubes[i].transform.Find("Up").name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 2)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[2];

                upCubes[i].transform.Find("Up").name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 3)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[3];

                upCubes[i].transform.Find("Up").name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 4)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[4];

                upCubes[i].transform.Find("Up").name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 5)
            {
                Renderer renderer = upCubes[i].transform.Find("Up").GetComponent<Renderer>();
                renderer.material.color = cubeColorsArray[5];

                upCubes[i].transform.Find("Up").name = "Front";
            }
        }
        cubeSideReader.ReadCubeState();
    }
}
