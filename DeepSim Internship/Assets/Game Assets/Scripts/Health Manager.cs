using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public List<Sprite> healthSprites = new List<Sprite>();
    public SpriteRenderer spriteRenderer;

    [Header("Health Values")]

    public float originalHealth;
    public float currentHealth;

    [Header("Sprite Values")]

    public float healthOne;
    public float healthTwo;
    public float healthThree;
    public float healthFour;
    public float healthFive;
    public float healthSix;

    [Header("Death Effects")]

    public ParticleSystem deathFX;

    private void Start()
    {
        deathFX.Stop();
        originalHealth = healthOne;
        currentHealth = originalHealth;
    }

    public void TakeDamage(float damageAmnt)
    {
        currentHealth -= damageAmnt;
    }

    private void Update()
    {
        HealthManagement();
    }

    void HealthManagement()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(PlayDeathEffects(0.1f));
        }

        else if (currentHealth <= healthOne && currentHealth > healthTwo)
        {
            spriteRenderer.sprite = healthSprites[0];
        }

        else if (currentHealth <= healthTwo && currentHealth > healthThree)
        {
            spriteRenderer.sprite = healthSprites[1];
        }

        else if (currentHealth <= healthThree && currentHealth > healthFour)
        {
            spriteRenderer.sprite = healthSprites[2];
        }

        else if (currentHealth <= healthFour && currentHealth > healthFive)
        {
            spriteRenderer.sprite = healthSprites[3];
        }

        else if (currentHealth <= healthFive && currentHealth > healthSix)
        {
            spriteRenderer.sprite = healthSprites[4];
        }

        else if (currentHealth < healthSix)
        {
            spriteRenderer.sprite = healthSprites[5];
        }
    }

    private IEnumerator PlayDeathEffects(float time)
    {
        var particleObj = Instantiate(deathFX.gameObject, transform.position, transform.rotation);
        deathFX.Play();
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}