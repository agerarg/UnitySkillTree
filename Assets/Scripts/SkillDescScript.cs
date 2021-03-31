using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Skill", menuName = "Custom/Skills")]
public class SkillDescScript : ScriptableObject
{
    public string skillName = "";
    public bool isPassive = false;
    public Texture skillImage;
    [TextArea]
    public string langDesc = "";

    public string[] statsGrown;

    public bool isFlatStat=false;
    public float[] fristStatMultiplier;
    public float[] secondStatMultiplier;
    public float[] terthStatMultiplier;

    public bool isCustom = false;

    public void Apply(int level)
    {
        if(isPassive)
        {
            int index = 0;
            float multiplier = 1;
            foreach (string statchang in statsGrown)
            {
                index++;
                switch (index)
                {
                    case 1:
                        multiplier = fristStatMultiplier[(level - 1)];
                        break;
                    case 2:
                        multiplier = secondStatMultiplier[(level - 1)];
                        break;
                    case 3:
                        multiplier = terthStatMultiplier[(level - 1)];
                        break;
                }
              
                   // (int)multiplier);
                
            }
        }
    }

    public string processDesc(int level=1)
    {

       // langDesc

        string text = langDesc;
        int index = 0;
        float multiplier = 1;
        foreach (string statchang in statsGrown)
        {
            index++;
            if(!isCustom || index != 1)
            switch(index)
            {
                case 1:
                    multiplier = fristStatMultiplier[(level - 1)];
                break;
                case 2:
                    multiplier = secondStatMultiplier[(level - 1)];
                break;
                case 3:
                    multiplier = terthStatMultiplier[(level - 1)];
                break;
            }
            if(isCustom && index==1)
            {
                text = text.Replace("(%" + index + ")", " algo raro ");
            } else 
            if(isFlatStat)
                text = text.Replace("(%" + index + ")", "" + (int)multiplier);
            else
                text = text.Replace("(%"+ index + ")", "<#7F00FF>( Attack * " + Math.Round(multiplier, 2) + " )</color>=" + (int)(100 * multiplier));
        }

        return text;
    }

}
