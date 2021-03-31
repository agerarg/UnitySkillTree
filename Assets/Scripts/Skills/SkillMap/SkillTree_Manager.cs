using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTree_Manager : MonoBehaviour
{
    public static SkillTree_Manager instance;
    public TextMeshProUGUI skillPointsText;
    public int skillPoints = 10;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateSkillPoints();
    }

    public void UpdateSkillPoints()
    {
        skillPointsText.SetText("Puntos:"+ skillPoints);
    }

    public void GetSkills()
    {
       
        SkillTree_Slot[] skillsSlots = FindObjectsOfType<SkillTree_Slot>();

       
         //Check LearnSkill
        foreach (SkillTree_Slot slot in skillsSlots)
        {

            if (slot.isLearned)
            {
                Debug.Log("Aprendiste " + slot.skillScript.name + " lvl:" + slot.skillLevel);
            }
        }

       gameObject.SetActive(false);
    }
   
}
