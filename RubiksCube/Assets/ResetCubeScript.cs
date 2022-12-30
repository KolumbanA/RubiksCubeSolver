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
    GameObject[] downCubes = new GameObject[9];
    GameObject[] frontCubes = new GameObject[9];
    GameObject[] backCubes = new GameObject[9];
    GameObject[] rightCubes = new GameObject[9];
    GameObject[] leftCubes = new GameObject[9];

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

        upCubes[0] = cubePiece23;
        upCubes[1] = cubePiece24;
        upCubes[2] = cubePiece20;
        upCubes[3] = cubePiece19;
        upCubes[4] = cubePiece12;
        upCubes[5] = cubePiece22;
        upCubes[6] = cubePiece25;
        upCubes[7] = cubePiece21;
        upCubes[8] = cubePiece26;

        downCubes[0] = cubePiece16;
        downCubes[1] = cubePiece17;
        downCubes[2] = cubePiece11;
        downCubes[3] = cubePiece13;
        downCubes[4] = cubePiece6;
        downCubes[5] = cubePiece14;
        downCubes[6] = cubePiece10;
        downCubes[7] = cubePiece9;
        downCubes[8] = cubePiece15;

        frontCubes[0] = cubePiece25;
        frontCubes[1] = cubePiece21;
        frontCubes[2] = cubePiece26;
        frontCubes[3] = cubePiece7;
        frontCubes[4] = cubePiece18;
        frontCubes[5] = cubePiece8;
        frontCubes[6] = cubePiece16;
        frontCubes[7] = cubePiece17;
        frontCubes[8] = cubePiece11;

        rightCubes[0] = cubePiece26;
        rightCubes[1] = cubePiece22;
        rightCubes[2] = cubePiece20;
        rightCubes[3] = cubePiece8;
        rightCubes[4] = cubePiece2;
        rightCubes[5] = cubePiece3;
        rightCubes[6] = cubePiece11;
        rightCubes[7] = cubePiece14;
        rightCubes[8] = cubePiece15;

        leftCubes[0] = cubePiece23;
        leftCubes[1] = cubePiece19;
        leftCubes[2] = cubePiece25;
        leftCubes[3] = cubePiece5;
        leftCubes[4] = cubePiece1;
        leftCubes[5] = cubePiece7;
        leftCubes[6] = cubePiece10;
        leftCubes[7] = cubePiece13;
        leftCubes[8] = cubePiece16;

        backCubes[0] = cubePiece20;
        backCubes[1] = cubePiece24;
        backCubes[2] = cubePiece23;
        backCubes[3] = cubePiece3;
        backCubes[4] = cubePiece4;
        backCubes[5] = cubePiece5;
        backCubes[6] = cubePiece15;
        backCubes[7] = cubePiece9;
        backCubes[8] = cubePiece10;
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
        
        foreach (GameObject piece in frontCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            Renderer renderer = allChildren[2].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[5];
        }
        
        foreach (GameObject piece in rightCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            Renderer renderer = allChildren[6].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[3];
        }

        foreach (GameObject piece in backCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            Renderer renderer = allChildren[1].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[4];
        }

        foreach (GameObject piece in downCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            Renderer renderer = allChildren[3].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[1];
        }

        foreach (GameObject piece in leftCubes)
        {
            Transform[] allChildren = piece.GetComponentsInChildren<Transform>();

            allChildren[1].name = "Back";
            allChildren[2].name = "Front";
            allChildren[3].name = "Down";
            allChildren[4].name = "Up";
            allChildren[5].name = "Left";
            allChildren[6].name = "Right";

            Renderer renderer = allChildren[5].GetComponent<Renderer>();
            renderer.material.color = cubeColorsArray[0];
        }
        
        cubeSideReader.ReadCubeState();
    }


    public void FillCube ()
    {
        //itt a kockak kis kockainak a neveit es szineit is reseteli
        ResetCube();

        // up cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 0)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[4].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 1)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[4].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 2)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[4].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 3)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[4].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 4)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[4].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsUp[i] == 5)
            {
                Transform[] allSides = upCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[4].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[4].transform.name = "Front";
            }
        }

        // front cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 0)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[2].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 1)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[2].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 2)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[2].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 3)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[2].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 4)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[2].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsFront[i] == 5)
            {
                Transform[] allSides = frontCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[2].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[2].transform.name = "Front";
            }
        }

        // right cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 0)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[6].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 1)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[6].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 2)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[6].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 3)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[6].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 4)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[6].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsRight[i] == 5)
            {
                Transform[] allSides = rightCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[6].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[6].transform.name = "Front";
            }
        }

        // back cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 0)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[1].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 1)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[1].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 2)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[1].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 3)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[1].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 4)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[1].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsBack[i] == 5)
            {
                Transform[] allSides = backCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[1].transform.name = "Front";
            }
        }

        // down cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 0)
            {
                Transform[] allSides = downCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[3].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[3].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 1)
            {
                Transform[] allSides = downCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[3].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[3].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 2)
            {
                Transform[] allSides = downCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[3].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[3].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 3)
            {
                Transform[] allSides = downCubes[3].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[1].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[3].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 4)
            {
                Transform[] allSides = downCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[3].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[3].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsDown[i] == 5)
            {
                Transform[] allSides = downCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[3].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[3].transform.name = "Front";
            }
        }

        // left cubes set
        for (int i = 0; i < 9; ++i)
        {
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 0)
            {
                Transform[] allSides = leftCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[0];

                allSides[5].transform.name = "Left";
            }
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 1)
            {
                Transform[] allSides = leftCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[1];

                allSides[5].transform.name = "Down";
            }
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 2)
            {
                Transform[] allSides = leftCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[2];

                allSides[5].transform.name = "Up";
            }
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 3)
            {
                Transform[] allSides = leftCubes[3].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[3];

                allSides[5].transform.name = "Right";
            }
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 4)
            {
                Transform[] allSides = leftCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[4];

                allSides[5].transform.name = "Back";
            }
            if (ReadCubeCubeMap.cubeMapColorsLeft[i] == 5)
            {
                Transform[] allSides = leftCubes[i].GetComponentsInChildren<Transform>();
                Renderer renderer = allSides[5].GetComponent<Renderer>(); ;
                renderer.material.color = cubeColorsArray[5];

                allSides[5].transform.name = "Front";
            }
        }

        cubeSideReader.ReadCubeState();
    }
}
