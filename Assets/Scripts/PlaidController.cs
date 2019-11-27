using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaidController : MonoBehaviour, IPointerClickHandler
{
    private GameObject colorObj;
    public int index = -1;
    public bool hasColor = false;

    // Start is called before the first frame update
    void Start()
    {
        colorObj = this.transform.Find("Color").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        hasColor = true;
        if(colorObj == null)
            colorObj = this.transform.Find("Color").gameObject;
        colorObj.GetComponent<Image>().color = color;
    }

    public Color GetColor()
    {
        if (!hasColor) return Color.white;
        return colorObj.GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasColor && eventData.button == PointerEventData.InputButton.Left)
        {
            ToolPalette_Plane.Instance.SetColor(GetColor());
        }
    }
}
