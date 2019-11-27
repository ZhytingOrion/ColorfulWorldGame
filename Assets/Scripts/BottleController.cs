using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour {

    public List<GameObject> inks = new List<GameObject>();
    private List<Color> ink_colors = new List<Color>();
    //public Sprite finalInk;
    public Transform ink_parent;
    public GameObject inkPrefab;
    public GameObject inkFx;
    [HideInInspector]
    public int Index;

    private float first_color_loc = -0.6f;
    private float colors_space = 0.1f;
    private float MaxY = 0.1f;
    private bool isInMix = false;
    private bool isCaptureState = false;
    private int MaxNum = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isInMix)
        {
            if(Input.GetMouseButtonDown(1))
            {
                MixInk();
            }
        }

        if(isCaptureState)
        {
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(CaptureInkColor());
            }
        }
	}

    public void StartCapture()
    {
        isCaptureState = true;
    }

    public void StopCapture()
    {
        isCaptureState = false;
    }

    public void GetInk()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(Vector3.zero);
        Vector3 mousePosOnScreen = Input.mousePosition;
        mousePosOnScreen.z = screenPos.z;
        inkFx.transform.position = Camera.main.ScreenToWorldPoint(mousePosOnScreen);

        StartCoroutine(GetInkAnim(0.5f));
    }

    private IEnumerator GetInkAnim(float time)
    {
        float Max_angle = 0.5f;
        float angle = Max_angle;

        Color c = inks[inks.Count - 1].GetComponent<SpriteRenderer>().color;

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            angle = Max_angle - t / time * Max_angle;
            inkFx.GetComponent<Renderer>().sharedMaterial.SetFloat("_Angle", angle);
            c.a = t / time;
            inks[inks.Count - 1].GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }

        inkFx.GetComponent<Renderer>().sharedMaterial.SetFloat("_Angle", 0);
    }


    public void SetInks(int index, List<Color> colors)
    {
        this.Index = index;
        float locY = first_color_loc;
        for(int i = 0; i<colors.Count; ++i)
        {
            AddInk(colors[i]);
        }
    }

    public void AddInk(Color color)
    {
        GameObject ink = Instantiate(inkPrefab);//Resources.Load<GameObject>("Prefab/Goods/Bottle_Ink"), ink_parent);
        ink.transform.parent = ink_parent;
        ink.transform.localRotation = Quaternion.Euler(Vector3.zero);
        ink.GetComponent<SpriteRenderer>().color = color;
        Vector3 pos = ink.transform.localPosition;
        pos.x = 0;
        pos.y = first_color_loc + colors_space * inks.Count;
        pos.z = 0;
        ink.transform.localPosition = pos;

        inks.Add(ink);
        ink_colors.Add(color);
        if (inks.Count >= MaxNum) StopCapture();
    }

    IEnumerator CaptureInkColor()
    {
        yield return new WaitForEndOfFrame();
        Texture2D m_texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        m_texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        m_texture.Apply();
        Color color = m_texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);
        AddInk(color);
        GetInk();
        StopCoroutine(CaptureInkColor());
    }

    public void MixInk()
    {
        Color mix_ink = GetInkColor();

        StartCoroutine(MixAnim(1.5f, mix_ink));
    }

    private Color GetInkColor()
    {
        float R = 0f, G = 0f, B = 0f, A = 0f;
        for(int i = 0; i<ink_colors.Count; ++i)
        {
            Color c = ink_colors[i];
            R += c.r;
            G += c.g;
            B += c.b;
            A += c.a;
        }
        return new Color(R / inks.Count, G / inks.Count, B / inks.Count, A / inks.Count);
    }

    private IEnumerator MixAnim(float time, Color mix_ink)
    {
        isInMix = true;
        float upY = 0.0f;
        float speed = 1f / time;
        MaxY = first_color_loc + colors_space * inks.Count;

        Color[] colors = new Color[inks.Count];
        for(int i = 0; i< inks.Count; ++i)
        {
            colors[i] = inks[i].GetComponent<SpriteRenderer>().color;
        }

        for(float t = 0f; t < time; t += Time.deltaTime)
        {
            if(Input.GetMouseButtonDown(0))
                break;
            upY += t * speed;
            for(int i = 0; i<inks.Count; ++i)
            {
                Vector3 pos = inks[i].transform.localPosition;
                pos.y += upY;
                while(pos.y > MaxY) pos.y -= colors_space * inks.Count;
                while(pos.y < first_color_loc) pos.y += colors_space * inks.Count;
                inks[i].transform.localPosition = pos;

                inks[i].GetComponent<SpriteRenderer>().color = Color.Lerp(colors[i], mix_ink, t / time);
            }
            yield return null;
        }

        for(int i = 0; i<inks.Count; ++i)
        {
            Vector3 pos = inks[i].transform.localPosition;
            pos.y = first_color_loc + colors_space * i;
            inks[i].transform.localPosition = pos;
            inks[i].GetComponent<SpriteRenderer>().color = mix_ink;
        }
        isInMix = false;
    }

    void OnDestroy()
    {
        InksManager.Instance.AddInkInfo(ink_colors, GetInkColor());
    }
}
