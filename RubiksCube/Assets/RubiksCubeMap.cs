using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubiksCubeMap : MonoBehaviour
{
    CubeState cubeState;

    public Transform tUp;
    public Transform tDown;
    public Transform tFront;
    public Transform tBack;
    public Transform tLeft;
    public Transform tRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();
        UpdateMap(cubeState.front, tFront);
        UpdateMap(cubeState.back, tBack);
        UpdateMap(cubeState.left, tLeft);
        UpdateMap(cubeState.right, tRight);
        UpdateMap(cubeState.down, tDown);
        UpdateMap(cubeState.up, tUp);

    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach(Transform map in side)
        {
            switch (face[i].name[0])
            {
                case 'B':
                    map.GetComponent<Image>().color = Color.white;
                    break;
                case 'F':
                    map.GetComponent<Image>().color = Color.yellow;
                    break;
                case 'U':
                    map.GetComponent<Image>().color = Color.blue;
                    break;
                case 'D':
                    map.GetComponent<Image>().color = Color.green;
                    break;
                case 'L':
                    map.GetComponent<Image>().color = Color.red;
                    break;
                case 'R':
                    map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                    break;
                default:
                    break;
            }

            ++i;
        }
    }
}
