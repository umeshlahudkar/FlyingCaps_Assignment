using UnityEngine;
using Shooter.Interface;
using Shooter.Health;
using Shooter.Global;

namespace Shooter.TowerSevice
{
    public class TowerView : MonoBehaviour, IDamageble
    {
        private TowerController towerController;
        public HealthController healthController;
        [SerializeField] private Transform weapon;
        [SerializeField] private Transform firePosition;

        private float timeElapced;
        private float timeBetweenFire;

        private void Start()
        {
            timeBetweenFire = towerController.towerModel.timeBetweenFire;
        }

        private void Update()
        {
            towerController.RotateWeapon(weapon);

            timeElapced += Time.deltaTime;
            if (timeElapced >= timeBetweenFire)
            {
                timeElapced = 0;
                towerController.Fire(firePosition);
            }
        }

        public void SetTowerController(TowerController towerController)
        {
            this.towerController = towerController;
        }

        public void TakeDamage(float damage)
        {
            healthController.TakeDamage(damage);
        }

        public CharacterType GetCharacterType()
        {
            return towerController.characterType;
        }

        public void Disable()
        {
            towerController.Disable();
        }
    }
}
