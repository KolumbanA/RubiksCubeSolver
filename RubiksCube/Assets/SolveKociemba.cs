using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;
using System;

public class SolveKociemba : MonoBehaviour
{
    public CubeSideReader cubeSideReader;
    public CubeState cubeState;
    public bool doOnce = true;
    void Start()
    {
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        cubeState = FindObjectOfType<CubeState>();
    }

    void Update()
    {
        if(CubeState.gameLoaded && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        cubeSideReader.ReadCubeState();
        //get state of cube in a string

        string moveString = cubeState.GetStateString();
        print(moveString);

        //solving the cube
        string info = "";

        //first solve --> need to generate tables --> slow
        //string solution = SearchRunTime.solution(moveString, out info, buildTables: true);



        //other times tables are generated --> fast solve
        string solution = Search.solution(moveString, out info);
        print(solution);

        
        //solved moves convert from string to list
        List<string> solutionList = StringToList(solution);


        //List < string> solutionList = new List<string> { "U", "U", "U", "U" };
        //print(solutionList);
        
        //solving
        AutoRotation.moveList = solutionList;

        print(info);
        
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
