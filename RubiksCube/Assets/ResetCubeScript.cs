using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCubeScript : MonoBehaviour
{
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

    GameObject fullCube;

    public CubeSideReader cubeSideReader;
    public RubiksCubeMap rubiksCubeMap;
    public GameObject rubiksCubeHolder;
    public GameObject rubiksCube;
    void Start()
    {
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        rubiksCubeMap = FindObjectOfType<RubiksCubeMap>();
        rubiksCubeHolder = GameObject.Find("Target");
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

    }

    void Update()
    {
        
    }

    public void ResetCube()
    {
        //rubiksCubeHolder.transform.eulerAngles = new Vector3(0, 0, 0);
        

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


        cubePiece1.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece2.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece3.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece4.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece5.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece6.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece7.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece8.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece9.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece10.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece11.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece12.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece13.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece14.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece15.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece16.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece17.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece18.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece19.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece20.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece21.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece22.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece23.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece24.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece25.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;
        cubePiece26.transform.eulerAngles = rubiksCubeHolder.transform.eulerAngles;

        cubeSideReader.ReadCubeState();
    }
}
