using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;

    public HealthBar healthBar;

    private Animator anim;
    public string sceneName;

    [SerializeField] private AudioSource deathSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {
            Die();
        }
    }

    private void Die ()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

}
