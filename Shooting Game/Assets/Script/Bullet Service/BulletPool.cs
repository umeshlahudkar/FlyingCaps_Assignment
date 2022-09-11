using UnityEngine;
using Shooter.Global;
using Shooter.SO;

namespace Shooter.BulletSevice
{
    public class BulletPool : ObjectPool<BulletController>
    {
        private BulletSO bulletSO;
        private Transform spwanLocation;
        private float LaunchForce;
        private BulletService bulletService;
        private CharacterType characterType;

        public BulletController GetItem(BulletSO bulletSO, Transform spwanPosition, float launchForce, CharacterType characterType, BulletService bulletService)
        {
            this.bulletSO = bulletSO;
            this.spwanLocation = spwanPosition;
            this.LaunchForce = launchForce;
            this.bulletService = bulletService;
            this.characterType = characterType;

            return GetItem();
        }

        public override BulletController CreateNew()
        {
            BulletController bulletController = new BulletController(bulletSO, spwanLocation, LaunchForce, characterType, bulletService);
            return bulletController;
        }
    }
}
