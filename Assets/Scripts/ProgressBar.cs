using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    //variables
    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] Image placeFilter;
    private int m_Progress;

    void Update()
    {
        m_Progress = ConvertFloatToInt(placeFilter.fillAmount);        
        m_TextMeshPro.text = placeFilter.fillAmount.ToString()+"%";
                
    }
    public int ConvertFloatToInt(float floatValue)
    {
        int intValue = Mathf.RoundToInt(floatValue * 100);
        return intValue;
    }
}
