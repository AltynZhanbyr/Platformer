using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public Text BulletsText;

    public int BulletsCount;

    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        base.Shot();
        BulletsCount--;
        UpdateText();
        if (BulletsCount <= 0) 
        {
            PlayerArmory.TakeGunByIndex(0);
        }
    }
    public override void ActivateGun()
    {
        base.ActivateGun();
        BulletsText.enabled = true;
        UpdateText();
    }
    public override void DeactivateGun()
    {
        base.DeactivateGun();
        BulletsText.enabled = false;
    }
    private void UpdateText() 
    {
        BulletsText.text = $"Пули: {BulletsCount.ToString()}";
    }
    public override void AddBullets(int bulletCount)
    {
        BulletsCount += bulletCount;
        UpdateText();
    }
}
