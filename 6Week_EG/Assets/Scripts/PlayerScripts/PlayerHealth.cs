using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    private bool _invincible=false;

    public AudioSource AddHealthSound;

    public HealthUI HealthUI;

    public UnityEvent EvenOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(this.Health);
    }
    public void TakeDamage(int damage)
    {
        if(!_invincible)
        {
            this.Health-=damage;
            if(this.Health<=0)
            {
                this.Health=0;
                Die();
            }
            _invincible=true;
            Invoke("StopInvincible",1f);
            HealthUI.DisplayHealth(this.Health);
            EvenOnTakeDamage.Invoke();
        }
    }
    public void AddHealth(int health)
    {
        this.Health+=health;
        AddHealthSound.Play();
        if(this.Health>MaxHealth)
        {
            this.Health=MaxHealth;
        }
        HealthUI.DisplayHealth(this.Health);
    }
    private void StopInvincible()
    {
        _invincible=false;
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
