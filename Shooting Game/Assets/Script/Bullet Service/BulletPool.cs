using UnityEngine;

public class BulletPool : ObjectPool<BulletController>
{
    private BulletView bulletPrefab;
    private Transform spwanLocation;
    private float LaunchForce;
    private BulletService bulletService;

    public BulletController GetItem(BulletView bulletView, Transform spwanPosition, float launchForce, BulletService bulletService)
    {
        this.bulletPrefab = bulletView;
        this.spwanLocation = spwanPosition;
        this.LaunchForce = launchForce;
        this.bulletService = bulletService;

        return GetItem();
    }

    public override BulletController CreateNew()
    {
        BulletController bulletController = new BulletController(bulletPrefab, spwanLocation, LaunchForce, bulletService);
        return bulletController;
    }
}
