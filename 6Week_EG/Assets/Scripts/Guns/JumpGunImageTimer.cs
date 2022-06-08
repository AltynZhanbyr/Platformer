using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpGunImageTimer : MonoBehaviour
{
    public Image BackGround;
    public Image ForeGround;

    public Text TimerText;

    public void StartCharge()
    {
        BackGround.color = new Color(1, 1, 1, 0.2f);
        ForeGround.enabled = true;
        TimerText.enabled = true;
    }
    public void StopCharge()
    {
        ForeGround.enabled = false;
        TimerText.enabled = false;
        BackGround.color = new Color(1, 1, 1, 1f);
    }
    public void SetChargeValue(float currentValue,float maxValue) 
    {
        ForeGround.fillAmount = currentValue / maxValue;
        TimerText.text = Mathf.Ceil(maxValue - currentValue).ToString();
    }
}
