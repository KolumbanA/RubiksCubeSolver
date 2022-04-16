using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCubeCubeMap : MonoBehaviour
{
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMap(Transform side, Color[] color)
    {

        side.GetChild(0).GetComponent<Image>().color = color[0];
        side.GetChild(1).GetComponent<Image>().color = color[1];
        side.GetChild(2).GetComponent<Image>().color = color[2];
        side.GetChild(3).GetComponent<Image>().color = color[3];
        side.GetChild(4).GetComponent<Image>().color = color[4];
        side.GetChild(5).GetComponent<Image>().color = color[5];
        side.GetChild(6).GetComponent<Image>().color = color[6];
        side.GetChild(7).GetComponent<Image>().color = color[7];
        side.GetChild(8).GetComponent<Image>().color = color[8];

    }
}
