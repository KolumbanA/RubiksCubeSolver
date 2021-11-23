using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeSideReader : MonoBehaviour
{

    public Transform tUp;
    public Transform tDown;
    public Transform tFront;
    public Transform tBack;
    public Transform tLeft;
    public Transform tRight;
    

    private int layerMask = 1 << 8; // layer mask for faces/(color of faces) of rubiks cube

    CubeState cubeState;
    RubiksCubeMap rubiksCubeMap;
    
    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        rubiksCubeMap = FindObjectOfType<RubiksCubeMap>();

        List<GameObject> facesHit = new List<GameObject>();
        Vector3 ray = tFront.transform.position;
        RaycastHit hit;

        // ************ 5000 distance lehet problemas lesz kesobb ************ ************ ************
        if (Physics.Raycast(ray, tFront.right, out hit, 5000, layerMask))
        {
            Debug.DrawRay(ray, tFront.right * hit.distance, Color.yellow);
            facesHit.Add(hit.collider.gameObject);
            print(hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawRay(ray, tFront.right * 1000, Color.green);
        }

        cubeState.front = facesHit;
        rubiksCubeMap.Set();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
