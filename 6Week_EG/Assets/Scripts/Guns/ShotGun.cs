using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : Gun
{
    [Header("ShotGun")]
    public Text BulletsText;

    public int BulletsCount;

    public Transform[] Spawns;

    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        GameObject[] newBullets = new GameObject[Spawns.Length];
        for (int i = 0; i < Spawns.Length; i++) 
        {
            newBullets[i] = Instantiate(BulletPrefab, Spawns[i].position, Spawns[i].localRotation);
            newBullets[i].GetComponent<Rigidbody>().AddForce(Spawns[i].forward * BulletSpeed, ForceMode.VelocityChange);
        }
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("TurnOff", 0.12f);
        BulletsCount--;
        UpdateText();
        if (BulletsCount <= 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
        ShotSmoke.Play();
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
