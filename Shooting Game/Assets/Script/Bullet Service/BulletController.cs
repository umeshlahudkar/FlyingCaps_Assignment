using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    private BulletService bulletService;
    public BulletModel bulletModel { get; private set; }
    public CharacterType characterType { get; private set; }

    public BulletController(BulletView bulletPrefab, Transform spwanLocation, float LaunchForce, CharacterType characterType, BulletService bulletService)
    {
        bulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
        bulletModel = new BulletModel();
        Enable(spwanLocation, LaunchForce, characterType);
        bulletView.SetBulletController(this);
        this.bulletService = bulletService;
    }

    public void Enable(Transform spwanLocation , float launchForce, CharacterType characterType)
    {
        bulletView.transform.position = spwanLocation.position;
        bulletView.transform.rotation = spwanLocation.rotation;
        this.characterType = characterType;
        bulletView.gameObject.SetActive(true);
        Fire(bulletView.GetRigidbody2D(), launchForce);
    }

    private void Fire(Rigidbody2D rb2D,float launchForce)
    {
        rb2D.velocity = bulletView.transform.up * launchForce;
    }

    public void Disable()
    {
        bulletView.gameObject.SetActive(false);
        bulletService.ReturnToPool(this);
    }
}
