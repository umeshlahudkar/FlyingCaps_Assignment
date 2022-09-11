using System;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private BulletView bulletPrefab;

    public void GetBullet(Transform spwanLocation, float launchForce, CharacterType characterType)
    {
        BulletController bulletController = bulletPool.GetItem(bulletPrefab, spwanLocation, launchForce, characterType, this);
        bulletController.Enable(spwanLocation, launchForce, characterType);
    }

    public void ReturnToPool(BulletController bulletController)
    {
        bulletPool.ReturnToPool(bulletController);
    }
}
