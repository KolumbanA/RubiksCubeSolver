using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging = false;
    private float sensitivity = 0.5f;
    private Vector3 rotation;

    private CubeSideReader cubeSideReader;
    private CubeState cubeState;

    // Start is called before the first frame update
    void Start()
    {
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            SpinSide(activeSide);
            if(Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }
        }
    }

    private void SpinSide(List<GameObject> side)
    {
        rotation = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - mouseRef);


        //nem jol szamolja ki a rotationt
        if(side == cubeState.front)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
            //print(rotation);
        }

        transform.Rotate(rotation, Space.Self);

        mouseRef = Input.mousePosition;
    }    

    public void Rotate(List<GameObject> side)
    {
        activeSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;

        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
    }
}
