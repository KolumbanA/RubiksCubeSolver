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

    private bool autoRotating = false;
    private Quaternion targetQuaternion;
    private float speed = 600f;

    private CubeSideReader cubeSideReader;
    private CubeState cubeState;

    // Start is called before the first frame update
    void Start()
    {
        cubeSideReader = FindObjectOfType<CubeSideReader>();
        cubeState = FindObjectOfType<CubeState>();
    }

    void LateUpdate()
    {
        if(dragging && !autoRotating)
        {
            SpinSide(activeSide);
            if(Input.GetMouseButtonUp(0))
            {
                dragging = false;
                Rotate90();
            }
        }

        if(autoRotating)
        {
            AutoRotate();
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
        if (side == cubeState.back)
        {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
            //print(rotation);
        }
        if (side == cubeState.up)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
            //print(rotation);
        }
        if (side == cubeState.down)
        {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
            //print(rotation);
        }
        if (side == cubeState.left)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
            //print(rotation);
        }
        if (side == cubeState.right)
        {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
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

    public void Rotate90()
    {
        Vector3 vec = transform.localEulerAngles;

        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;

        targetQuaternion.eulerAngles = vec;
        autoRotating = true;
    }

    private void AutoRotate()
    {
        dragging = false;
        var step = speed * Time.deltaTime;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);

        if(Quaternion.Angle(transform.localRotation, targetQuaternion) <= 1)
        {
            transform.localRotation = targetQuaternion;

            //le szedni a parentrol az oldalakat

            cubeState.PutDown(activeSide, transform.parent);
            cubeSideReader.ReadCubeState();

            autoRotating = false;
            dragging = false;
            CubeState.autoRotating = false;

        }
    }

    public void StartAutoRotate(List<GameObject> side, float angle)
    {
        cubeState.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }

   
}
