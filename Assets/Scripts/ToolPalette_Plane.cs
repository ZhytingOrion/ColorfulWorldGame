using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPalette_Plane : MonoBehaviour
{
    public static ToolPalette_Plane Instance = null;

    public Transform Plaids;
    public GameObject FirstPlaid;
    public GameObject LastPlaid;
    public int rowNum = 3;
    public int colNum = 5;
    public int page = 0;
    private Color cntColor = Color.white;
    private bool hasColor = false;

    private bool isShown = false;

    private List<GameObject> plaids = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitPlane();
        this.transform.localPosition = new Vector3(0, 238f - Screen.height,0f);
        isShown = false;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPlane()
    {
        float startX = FirstPlaid.transform.localPosition.x;
        float endX = LastPlaid.transform.localPosition.x;
        float diffX = (endX - startX) / (colNum - 1);
        float startY = FirstPlaid.transform.localPosition.y;
        float endY = LastPlaid.transform.localPosition.y;
        float diffY = (endY - startY) / (rowNum - 1);

        int index = page * rowNum * colNum;

        float posY = startY;
        for (int i = 0; i<rowNum; ++i)
        {
            float posX = startX;
            for (int j = 0; j<colNum; j++)
            {
                GameObject plaid = Instantiate(Resources.Load<GameObject>("Prefab/UI/Plaid"), Plaids);
                plaid.GetComponent<PlaidController>().index = index;
                if (index < InksManager.Instance.GetCount())
                    plaid.GetComponent<PlaidController>().SetColor(InksManager.Instance.GetMixedColor(index));
                plaid.transform.localPosition = new Vector3(posX, posY, 0);
                plaids.Add(plaid);
                index++;
                posX += diffX; 
            }
            posY += diffY;
        }
    }

    public void SetColor(Color color)
    {
        hasColor = true;
        cntColor = color;
    }

    public bool GetColor(out Color color)
    {
        if (hasColor)
            color = cntColor;
        else color = Color.white;
        return hasColor;
    }

    public void OnTouchPalette()
    {
        float startY = 0f, endY = 238f - Screen.height;
        if(!isShown)
        {
            startY = endY;
            endY = 0f;
        }
        StartCoroutine(ShowAnim(startY, endY, 0.5f));
        isShown = !isShown;
    }

    public IEnumerator ShowAnim(float startY, float endY, float during)
    {
        Vector3 pos = this.transform.localPosition;
        pos.y = startY;
        this.transform.localPosition = pos;

        for (float t = 0; t<during; t+=Time.deltaTime)
        {
            pos.y = Mathf.Lerp(startY, endY, t / during);
            this.transform.localPosition = pos;
            yield return null;
        }

        pos.y = endY;
        this.transform.localPosition = pos;
    }
}
