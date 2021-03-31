using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillTree_Slot : MonoBehaviour, IPointerClickHandler
     , IPointerEnterHandler
     , IPointerExitHandler
{
    public int skillLevel = 1;
    public SkillDescScript skillScript;

    public RawImage rawImageSkill;
    public SkillTree_Link[] linkToThis;

    public SkillTree_Link[] linkGoOut;

    public bool isLearned = false;    

    private RawImage m_RawImage;

    void Start()
    {
        m_RawImage = GetComponent<RawImage>();
        rawImageSkill.texture = skillScript.skillImage;
    }

    public void Learn()
    {
        if (!isLearned)
        {
            isLearned = true;
            m_RawImage.color = linkToThis[0].linkedColor;
            SkillTree_Manager.instance.skillPoints--;
            SkillTree_Manager.instance.UpdateSkillPoints();
        }
    }
    public void UnLearn()
    {
        if (isLearned)
        {
            isLearned = false;
            m_RawImage.color = Color.white;
            SkillTree_Manager.instance.skillPoints++;
            SkillTree_Manager.instance.UpdateSkillPoints();
        }
    }

    bool CheckLinkToThis()
    {
       foreach(SkillTree_Link links in linkToThis)
        {
            if (!links.isOpen)
                return false;
        }
        return true;
    }


    void LinkedLinks()
    {
        foreach (SkillTree_Link links in linkToThis)
        {
            links.Linked();
        }
    }

    void OpenLinks(SkillTree_Link[] arr)
    {
        foreach (SkillTree_Link links in arr)
        {
            links.OpenLink();
        }
    }
    void CloseLinks(SkillTree_Link[] arr)
    {
        foreach (SkillTree_Link links in arr)
        {
            links.CloseLink();
        }
    }

    bool CheckIfAnyLinkedToThis()
    {
        
       foreach (SkillTree_Link links in linkGoOut)
        {
            if (links.isLinked)
                return false;

        }
        return true;

    }

    public void OnPointerClick(PointerEventData eventData) 
    {
       
        if (CheckLinkToThis())
        {
            if (!isLearned && SkillTree_Manager.instance.skillPoints > 0)
            {
                if (linkGoOut.Length > 0)
                    OpenLinks(linkGoOut);
                LinkedLinks();
                Learn();
            }
            else
            {
                if (linkGoOut.Length > 0)
                {
                    if (CheckIfAnyLinkedToThis())
                    {

                        CloseLinks(linkGoOut);
                        OpenLinks(linkToThis);
                        UnLearn();
                    }
                }
                else
                {
                    OpenLinks(linkToThis);
                    UnLearn();
                }
            }


        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillTree_ToolTip.instance.ShowDesc(skillScript, skillLevel,transform.position);
        if (!isLearned)
        m_RawImage.color = Color.grey;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillTree_ToolTip.instance.HideDesc();
        if (!isLearned)
            m_RawImage.color = Color.white;
    }
}
