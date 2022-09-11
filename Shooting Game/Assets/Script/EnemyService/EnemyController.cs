using UnityEngine;
using Shooter.Global;
using Shooter.SO;
using Shooter.BulletSevice;
using Shooter.Event;

namespace Shooter.EnemyService
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }
        private Transform target = null;
        private EnemyService enemyService;
        private CharacterType characterType = CharacterType.Enemy;

        public EnemyController(EnemySO enemySO, Vector2 spwanPosition, EnemyService enemyService)
        {
            enemyView = GameObject.Instantiate<EnemyView>(enemySO.enemyPrefab, spwanPosition, Quaternion.identity);
            enemyModel = new EnemyModel(enemySO);
            enemyView.SetEnemyController(this);
            this.enemyService = enemyService;
        }

        public void Enable(Vector2 spwanPosition)
        {
            enemyView.transform.position = spwanPosition;
            enemyView.healthController.SetParameter(enemyModel.health, enemyModel.healthBarActiveTime);
            enemyView.gameObject.SetActive(true);
        }

        public void UpdateTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public void Move()
        {
            enemyView.transform.Translate(Vector2.right * Time.deltaTime * enemyModel.movementSpeed);
        }

        public void RotateWeapon(Transform weapon)
        {
            if (target != null)
            {
                Vector2 direction = (target.position - weapon.position).normalized;
                Quaternion lookTowards = Quaternion.LookRotation(Vector3.forward, direction);
                weapon.localRotation = Quaternion.Slerp(weapon.rotation, lookTowards, Time.deltaTime * enemyModel.weaponRotationSpeed);
            }
        }

        public void Fire(Transform firePosition)
        {
            BulletService.Instance.GetBullet(firePosition, enemyModel.bulletLaunchForce, characterType);
        }

        public CharacterType GetCharacterType()
        {
            return characterType;
        }

        public void Disable()
        {
            enemyView.gameObject.SetActive(false);
            enemyService.ReturnToPool(this);
            EventService.Instance.InvokeOnEnemyKilledEvent();
        }
    }
}

