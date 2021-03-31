using UnityEngine;
using TMPro;
public class SkillTree_ToolTip : MonoBehaviour
{
    public static SkillTree_ToolTip instance;
    public TextMeshProUGUI textDesc;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillLevel;

    public bool isDraginSkillTree = false;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        HideDesc();
    }

    public void ShowDesc(SkillDescScript skill,int level,Vector3 pos)
    {
        if (!isDraginSkillTree)
        {
            skillName.SetText(skill.skillName);
            skillLevel.SetText("Lvl:" + level);
            textDesc.SetText(skill.processDesc(level));
            transform.position = pos;
        }
    }

    public void HideDesc()
    {
        transform.position = new Vector3(-3000f, -3000f, 1);
    }
}
