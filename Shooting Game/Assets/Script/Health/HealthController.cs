using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Slider healthBarSlider;

    private IDamageble damageble;
    private Coroutine healthBarCoroutine;
    private int health = 100;
    private int healthBarActiveTime = 3;

    private void OnEnable()
    {
        health = 100;
        healthBar.SetActive(false);
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
        damageble = gameObject.GetComponent<IDamageble>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        ActivateHealthBar();
        UpdateHealthBar();

        if(health <= 0)
        {
            damageble.Disable();
        }
    }

    private void UpdateHealthBar()
    {
        healthBarSlider.value = health;
    }

    private void ActivateHealthBar()
    {
        if(healthBarCoroutine != null)
        {
            StopCoroutine(healthBarCoroutine);
        }

        healthBarCoroutine = StartCoroutine(EnableHealthBar());
    }

    IEnumerator EnableHealthBar()
    {
        healthBar.SetActive(true);

        yield return new WaitForSeconds(healthBarActiveTime);

        healthBar.SetActive(false);
    }
}
