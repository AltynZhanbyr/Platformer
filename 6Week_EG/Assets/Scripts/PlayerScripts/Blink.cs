using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public List<Renderer> Renderers=new List<Renderer>();

    public void StartBlink()
    {
        StartCoroutine(Blinking());
    } 
    public IEnumerator Blinking()
    {
        for(float t=0f;t<1f;t+=Time.deltaTime)
        {
            for(int i=0;i<Renderers.Count;i++)
            {
                for(int j=0;j<Renderers[i].materials.Length;j++)
                {
                 
                    Renderers[i].materials[j].SetColor("_EmissionColor",new Color(Mathf.Clamp(Mathf.Sin(t*30),0f,1f),0,0,0));
                    //Renderers[i].materials[j].SetColor("_EmissionColor", new Color(t, 0, 0, 0));
                }
            }
            yield return null;
        }
    }
}
