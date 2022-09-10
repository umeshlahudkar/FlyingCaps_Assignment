using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController 
{
    private EnemyView enemyView;
    private Transform target = null;

    public EnemyController(EnemyView enemyPrefab, Vector2 spwanPosition, Transform target,EnemyService enemyService)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemyPrefab, spwanPosition, Quaternion.identity);
        enemyView.SetEnemyController(this);
        this.target = target;
    }

    public void Move()
    {
        enemyView.transform.Translate(Vector2.right * Time.deltaTime);
    }

    public void RotateWeapon(Transform weapon)
    {
        if (target == null) return;

        Vector2 direction = (target.position - weapon.position).normalized;
        Quaternion lookTowards = Quaternion.LookRotation(Vector3.forward, direction);
        weapon.localRotation = Quaternion.Slerp(weapon.rotation, lookTowards, Time.deltaTime);
    }

    public void Fire(Transform firePosition)
    {
        BulletService.Instance.GetBullet(firePosition, 10);
    }
}
