using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoRotation : MonoBehaviour
{
    GameObject nextMoveButton;
    public static bool rotatingTurnedToAutomatic = false;
    public Text movesInMoveList;

    public static List<string> moveList = new List<string> { };
    private readonly List<string> allMoves = new List<string>
    { "U", "D", "L", "R", "F", "B",
      "U'", "D'", "L'", "R'", "F'", "B'",
      "U2", "D2", "L2", "R2", "F2", "B2"};


    private CubeState cubeState;
    private CubeSideReader cubeSideReader;
    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        nextMoveButton = GameObject.Find("Do_move_button");
    }

    // Update is called once per frame
    void Update()
    {
        if(moveList.Count > 0 && !CubeState.autoRotating && CubeState.gameLoaded && rotatingTurnedToAutomatic)
        {
            //do move
            DoMove(moveList[0]);
            //remove done move
            moveList.Remove(moveList[0]);
        }
        UpdateMoveListTextOnUi();
    }

    public void UpdateMoveListTextOnUi ()
    {
        movesInMoveList.text = string.Empty;

        //movesInMoveList.text = String.Join(",", moveList);
        for (int i = 0; i < moveList.Count; ++i)
        {
            movesInMoveList.text += moveList[i] + "  ";

            if (i > 5)
                break;
        }
        
    }

    public void DoOneMove()
    {
        if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.gameLoaded)
        {
            //do move
            DoMove(moveList[0]);
            //remove done move
            moveList.Remove(moveList[0]);
            UpdateMoveListTextOnUi();
        }
    }

    public void RandomizeCube()
    {
        List<string> moves = new List<string>();
        int moveNumbers = UnityEngine.Random.Range(15, 35);
        int randomMove;

        for (int i=0; i < moveNumbers; ++i)
        {
            randomMove = UnityEngine.Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
            //print(allMoves[randomMove]);
        }

        moveList = moves;
        UpdateMoveListTextOnUi();
    }

    void DoMove(string move)
    {
        cubeSideReader.ReadCubeState();
        CubeState.autoRotating = true;

        //moves possible with the cube
        if (move == "D")
        {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeState.down, -180);
        }

        if (move == "U")
        {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeState.up, -180);
        }

        if (move == "L")
        {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeState.left, -180);
        }

        if (move == "R")
        {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeState.right, -180);
        }

        if (move == "F")
        {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeState.front, -180);
        }

        if (move == "B")
        {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeState.back, -180);
        }
    }

    void RotateSide(List<GameObject> side, float angle)
    {
        SideRotation sr = side[4].transform.parent.GetComponent<SideRotation>();
        Debug.Log(sr);
        sr.StartAutoRotate(side, angle);
    } 
    
    public void ToggleAutoRotating()
    {
        if (rotatingTurnedToAutomatic)
        {
            rotatingTurnedToAutomatic = false;
            nextMoveButton.SetActive(true);
        }
        else
        {
            rotatingTurnedToAutomatic = true;
            nextMoveButton.SetActive(false);
        }
    }
}
