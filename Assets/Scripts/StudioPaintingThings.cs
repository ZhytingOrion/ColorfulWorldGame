using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class StudioInfo
{
    public List<PaintingInfo> paintingThings = new List<PaintingInfo>();
}

[Serializable]
public class PaintingInfo
{
    public int index;
    public int type;    //0：填色插图 1：手绘
    public string prefabName;    //图画的prefab名
    public List<Color> colors = new List<Color>();
}

public enum PaintingType
{
    ColorFilling,
    HandDrawn
}

public class StudioPaintingThings : MonoBehaviour
{
    public List<PaintingInfo> paintingInfo = new List<PaintingInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPainting(PaintingType type, GameObject paintingObj)
    {
        PaintingInfo info = new PaintingInfo();
        info.type = (int)type;
        info.prefabName = paintingObj.name.Replace("(Clone)", "");
        List<Color> colors = new List<Color>();
        for(int i = 0; i<paintingObj.transform.childCount; i++)
        {
            Transform t = paintingObj.transform.Find(i.ToString());
            if (t == null) continue;
            Image image = t.GetComponent<Image>();
            if (image == null) continue;
            colors.Add(image.color);
        }
        info.colors = colors;
        info.index = paintingInfo.Count;

        paintingInfo.Add(info);
    }

    public void LoadPainting(int index)
    {
        PaintingInfo info = paintingInfo.Find(x => x.index == index);
        if (info == null) return;

        //todo: 加载&换色
    }
}
