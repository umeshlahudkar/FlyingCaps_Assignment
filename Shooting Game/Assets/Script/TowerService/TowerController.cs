using UnityEngine;
using Shooter.Global;
using Shooter.SO;
using Shooter.BulletSevice;
using Shooter.Event;

namespace Shooter.TowerSevice
{
    public class TowerController
    {
        public TowerView towerView { get; private set; }
        public TowerModel towerModel { get; private set; }
        public CharacterType characterType { get; private set; }
        private Transform cursorPosition;
        private TowerService towerService;

        public TowerController(TowerSO towerSO, Transform cursorPosition, TowerService towerService)
        {
            towerView = GameObject.Instantiate<TowerView>(towerSO.tower.towerPrefab, towerSO.tower.spwanPosition, Quaternion.identity);
            towerModel = new TowerModel(towerSO);
            towerView.SetTowerController(this);
            characterType = CharacterType.Tower;
            this.cursorPosition = cursorPosition;
            this.towerService = towerService;
        }

        public void RotateWeapon(Transform weapon)
        {
            Vector2 direction = (cursorPosition.position - weapon.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            weapon.localRotation = Quaternion.Slerp(weapon.rotation, lookRotation, Time.deltaTime * towerModel.weaponRotationSpeed);
        }

        public void Enable()
        {
            towerView.healthController.SetParameter(towerModel.health, towerModel.healthBarActiveTime);
            towerView.gameObject.SetActive(true);
        }

        public void Fire(Transform firePositin)
        {
            BulletService.Instance.GetBullet(firePositin, towerModel.bulletLaunchForce, characterType);
        }

        public void Disable()
        {
            towerView.gameObject.SetActive(false);
            towerService.RetuenToPool(this);
            EventService.Instance.InvokeOnTowerDestroyEvent();
        }
    }

}
