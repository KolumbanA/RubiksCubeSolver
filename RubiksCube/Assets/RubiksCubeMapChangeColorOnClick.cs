using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RubiksCubeMapChangeColorOnClick : MonoBehaviour, IPointerClickHandler
{
    static int i = 0;
    Color[] cubeColorsArray = new Color[] { Color.red, Color.green, Color.blue, new Color(1, 0.5f, 0, 1), Color.white, Color.yellow };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.pointerCurrentRaycast.gameObject.transform.GetComponent<Image>().color = cubeColorsArray[i];

        if (++i > 5)
            i = 0;
    }

}
