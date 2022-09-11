using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Interface;

namespace Shooter.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private GameObject healthBar;
        [SerializeField] private Slider healthBarSlider;

        private IDamageble damageble;
        private Coroutine healthBarCoroutine;
        private float health;
        private float healthBarActiveTime;

        private void Start()
        {
            damageble = gameObject.GetComponent<IDamageble>();
        }

        public void SetParameter(float health, float healthBarActiveTime)
        {
            this.health = health;
            this.healthBarActiveTime = healthBarActiveTime;
            healthBar.SetActive(false);
            healthBarSlider.maxValue = health;
            healthBarSlider.value = health;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            health = Mathf.Max(health, 0);

            ActivateHealthBar();
            UpdateHealthBar();

            if (health <= 0)
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
            if (healthBarCoroutine != null)
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

}
