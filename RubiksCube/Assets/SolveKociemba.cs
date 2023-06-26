using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;
using System;
using System.Diagnostics;

public class SolveKociemba : MonoBehaviour
{
    public CubeSideReader cubeSideReader;
    public CubeState cubeState;
    public bool doOnce = true;

    static List<long> idok = new List<long>();
    static List<long> lepesszam = new List<long>();

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
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        cubeSideReader.ReadCubeState();
        //get state of cube in a string

        string moveString = cubeState.GetStateString();
        //print(moveString);

        //solving the cube
        string info = "";

        //first solve --> need to generate tables --> slow
        //string solution = SearchRunTime.solution(moveString, out info, buildTables: true);



        //other times tables are generated --> fast solve
        string solution = Search.solution(moveString, out info);
        //print(solution);

        if(solution.Contains("Error"))
        {
            return;
        }
        
        //solved moves convert from string to list
        List<string> solutionList = StringToList(solution);


        //List < string> solutionList = new List<string> { "U", "U", "U", "U" };
        //print(solutionList);
        
        //solving
        AutoRotation.moveList = solutionList;

        stopwatch.Stop();
        long time = stopwatch.ElapsedMilliseconds;

        idok.Add(time);
        lepesszam.Add(solutionList.Count);

        print(time);

        //print(info);
        
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
