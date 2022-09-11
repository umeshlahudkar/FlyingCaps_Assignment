using UnityEngine;
using Shooter.Global;
using Shooter.SO;

namespace Shooter.BulletSevice
{
    public class BulletService : GenericSingleton<BulletService>
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private BulletSO bulletSO;

        public void GetBullet(Transform spwanLocation, float launchForce, CharacterType characterType)
        {
            BulletController bulletController = bulletPool.GetItem(bulletSO, spwanLocation, launchForce, characterType, this);
            bulletController.Enable(spwanLocation, launchForce, characterType);
        }

        public void ReturnToPool(BulletController bulletController)
        {
            bulletPool.ReturnToPool(bulletController);
        }
    }
}

