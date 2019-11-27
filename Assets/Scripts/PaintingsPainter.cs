using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PaintingsPainter : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        if (ToolPalette_Plane.Instance == null)
        {
            ToolsManager.CreatePalette();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Paint();
    }

    void Paint()
    {
        if (ToolPalette_Plane.Instance == null) {
            ToolsManager.CreatePalette();
            return;
        }

        Color color;
        if (!ToolPalette_Plane.Instance.GetColor(out color))
            return;

        this.GetComponent<Image>().color = color;
    }
}
