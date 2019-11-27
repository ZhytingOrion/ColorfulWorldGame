using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsLogic : MonoBehaviour
{
    GameObject currentBottle = null;
    GameObject ToolPalette = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            currentBottle = Instantiate(Resources.Load<GameObject>("Prefab/Bottle"));
            currentBottle.GetComponent<BottleController>().StartCapture();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Destroy(currentBottle);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            if (ToolPalette == null)
                ToolPalette = Instantiate(Resources.Load<GameObject>("Prefab/UI/ToolPalette"), GameObject.Find("Canvas").transform);
            else
                Destroy(ToolPalette);
        }
    }
}
