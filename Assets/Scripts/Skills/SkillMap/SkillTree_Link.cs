using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree_Link : MonoBehaviour
{

    public bool isStart = false;
    public Color linkedColor;
    public Color openColor;
    public Color closeColor;

    public bool isOpen = false;
    public bool isLinked = false;

    private RawImage m_RawImage;
    
    void Start()
    {
        m_RawImage = GetComponent<RawImage>();

        CloseLink();
        if (isStart)
            OpenLink();
    }

    public void CloseLink()
    {
        m_RawImage.color = closeColor;
        isOpen = false;
        isLinked = false;
    }

    public void Linked()
    {
        m_RawImage.color = linkedColor;
        isLinked = true;
    }

    public void OpenLink()
    {
        m_RawImage.color = openColor;
        isOpen = true;
        isLinked = false;
    }

   
}
