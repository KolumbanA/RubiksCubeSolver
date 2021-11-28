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
            //print(face[0].name[0]);
            //print(i);
            //map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            /*if (face[i].name[0] == 'B')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }*/
            // **************** AZ IF NEM JO /NEM ISMERI FEL AZ OLDALT ******************
            if (face[i].name[0] == 'F')
            {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[0] == 'B')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name[0] == 'U')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name[0] == 'D')
            {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].name[0] == 'L')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].name[0] == 'R')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            ++i;
        }
    }
}
