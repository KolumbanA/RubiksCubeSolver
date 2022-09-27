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
		// this for finger swiping
		//Swipe();

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

	void RotateCubeInstantly()
	{
		transform.rotation = target.transform.rotation;
	}

	void Swipe()
	{
		if(Input.GetMouseButtonDown(1))
		{
			//Mouse position on click
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			//print(firstPressPos);
		}
		if(Input.GetMouseButtonUp(1))
		{
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - secondPressPos.x);
			
			currentSwipe.Normalize();
			
			/*if(LeftSwipe(currentSwipe))
			{
				target.transform.Rotate(0, 90, 0, Space.World);
			}
			else if(RightSwipe(currentSwipe))
			{
				target.transform.Rotate(0, -90, 0, Space.World);
			}
			else if(UpLeftSwipe(currentSwipe))
			{
				target.transform.Rotate(90, 0, 0, Space.World);
			}
			else if(UpRightSwipe(currentSwipe))
			{
				target.transform.Rotate(0, 0, -90, Space.World);
			}
			else if(DownLeftSwipe(currentSwipe))
			{
				target.transform.Rotate(0, 0, 90, Space.World);
			}
			else if(DownRightSwipe(currentSwipe))
			{
				target.transform.Rotate(-90, 0, 0, Space.World);
			}*/

		}
	}
	
	bool LeftSwipe(Vector2 swipe)
	{
		return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
	}
	
	bool RightSwipe(Vector2 swipe)
	{
		return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
	}
	
	bool UpLeftSwipe(Vector2 swipe)
	{
		return swipe.y > 0 && 	swipe.x < 0f;
	}
	
	bool UpRightSwipe(Vector2 swipe)
	{
		return swipe.y > 0 && 	swipe.x > 0f;
	}
	
	bool DownLeftSwipe(Vector2 swipe)
	{
		return swipe.y < 0 && 	swipe.x < 0f;
	}
	
	bool DownRightSwipe(Vector2 swipe)
	{
		return swipe.y < 0 && 	swipe.x > 0f;
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
