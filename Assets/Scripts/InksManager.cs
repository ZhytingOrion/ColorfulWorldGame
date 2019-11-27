using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class ToolsInk
{
    public List<InkInfo> inkInfos = new List<InkInfo>();
}

[Serializable]
public class InkInfo
{
    public int index;
    public List<Color> colors = new List<Color>();
    public Color mix_color;
}

public class InksManager : MonoBehaviour {

    public static InksManager Instance = null;
    private static string dataPath = "InksCollected.txt";

    private ToolsInk m_toolsInk;

    // Use this for initialization
    void Start () {
        Instance = this;
        GetAllInksCollected();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetAllInksCollected()
    {
        if(!File.Exists(Application.dataPath + "/" + dataPath))
        {
            m_toolsInk = new ToolsInk();
            return;
        }

        StreamReader sr = new StreamReader(Application.dataPath + "/" + dataPath);
        string json = sr.ReadToEnd();
        sr.Close();

        m_toolsInk = JsonUtility.FromJson<ToolsInk>(json);
    }

    public void AddInkInfo(InkInfo infos)
    {
        m_toolsInk.inkInfos.Add(infos);
    }

    public void AddInkInfo(List<Color> colors, Color mix_color)
    {
        InkInfo info = new InkInfo();
        info.colors = colors;
        info.mix_color = mix_color;
        info.index = m_toolsInk.inkInfos.Count;
        m_toolsInk.inkInfos.Add(info);
    }

    public List<Color> GetAllMixedColor()
    {
        List<Color> mixedColors = new List<Color>();
        for(int i = 0; i<m_toolsInk.inkInfos.Count; ++i)
        {
            mixedColors.Add(m_toolsInk.inkInfos[i].mix_color);
        }
        return mixedColors;
    }

    public Color GetMixedColor(int index)
    {
        if (index < m_toolsInk.inkInfos.Count) return m_toolsInk.inkInfos[index].mix_color;
        return Color.white;
    }

    public InkInfo GetInkInfo(int index)
    {
        if (index < m_toolsInk.inkInfos.Count) return m_toolsInk.inkInfos[index];
        return null;
    }

    public int GetCount()
    {
        return m_toolsInk.inkInfos.Count;
    }

    private void OnDestroy()
    {
        string recordsInfo = JsonUtility.ToJson(m_toolsInk);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + dataPath);

        sw.Write(recordsInfo);
        sw.Close();
    }
}
