using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWholeCube : MonoBehaviour
{
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	
	public GameObject target;
	float speed = 200f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		RotateCubeSmoothly();
	}

	void RotateCubeSmoothly ()
    {
		if (transform.rotation != target.transform.rotation)
		{
			var step = speed * Time.deltaTime;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
		}
	}

	public void RotateCubeInstantly()
	{
		transform.rotation = target.transform.rotation;
	}
	
	// Event triggers for rotating the whole cube
	
	public void RotateLeft()
	{
		target.transform.Rotate(0, 90, 0, Space.World);
		return;
	}
	
	public void RotateRight()
	{
		target.transform.Rotate(0, -90, 0, Space.World);
		return;
	}
	
	public void RotateUpLeft()
	{
		target.transform.Rotate(90, 0, 0, Space.World);
		return;
	}
	
	public void RotateUpRight()
	{
		target.transform.Rotate(0, 0, -90, Space.World);
		return;
	}
	
	public void RotateDownLeft()
	{
		target.transform.Rotate(0, 0, 90, Space.World);
		return;
	}
	
	public void RotateDownRight()
	{
		target.transform.Rotate(-90, 0, 0, Space.World);
		return;
	}
}
