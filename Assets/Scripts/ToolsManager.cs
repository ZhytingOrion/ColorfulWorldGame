using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static GameObject ToolPalette = null;

    public static void CreatePalette()
    {
        if (ToolPalette == null)
            ToolPalette = Instantiate(Resources.Load<GameObject>("Prefab/UI/ToolPalette"), GameObject.Find("Canvas").transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
