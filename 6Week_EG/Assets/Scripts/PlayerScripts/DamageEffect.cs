using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image DamageImage;

    private void Start()
    {
        DamageImage.enabled=false;
    }
    public void EffectStart()
    {
        StartCoroutine(ActiveEffect());
    }
    public IEnumerator ActiveEffect()
    {
        DamageImage.enabled=true;
        for(float t=0f;t<1f;t+=Time.deltaTime * 3.5f)
        {
            DamageImage.color=new Color(1f,0,0,t);
            yield return null;
        }
        for(float t=1f;t>0f;t-=Time.deltaTime * 3.5f)
        {
            DamageImage.color=new Color(1f,0,0,t);
            yield return null;
        }
        DamageImage.enabled=false;
    }
}
