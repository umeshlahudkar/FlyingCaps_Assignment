using System;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private BulletView bulletPrefab;

    public void GetBullet(Transform spwanLocation, float launchForce)
    {
        BulletController bulletController = bulletPool.GetItem(bulletPrefab, spwanLocation, launchForce, this);
        bulletController.Enable(spwanLocation, launchForce);
    }

    public void ReturnToPool(BulletController bulletController)
    {
        bulletPool.ReturnToPool(bulletController);
    }
}
