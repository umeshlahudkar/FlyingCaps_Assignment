using UnityEngine;

public class BulletPool : ObjectPool<BulletController>
{
    private BulletView bulletPrefab;
    private Transform spwanLocation;
    private float LaunchForce;
    private BulletService bulletService;
    private CharacterType characterType;

    public BulletController GetItem(BulletView bulletView, Transform spwanPosition, float launchForce, CharacterType characterType, BulletService bulletService)
    {
        this.bulletPrefab = bulletView;
        this.spwanLocation = spwanPosition;
        this.LaunchForce = launchForce;
        this.bulletService = bulletService;
        this.characterType = characterType;

        return GetItem();
    }

    public override BulletController CreateNew()
    {
        BulletController bulletController = new BulletController(bulletPrefab, spwanLocation, LaunchForce, characterType, bulletService);
        return bulletController;
    }
}
