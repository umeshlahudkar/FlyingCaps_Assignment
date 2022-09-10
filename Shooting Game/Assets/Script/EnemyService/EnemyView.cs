using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;

    [SerializeField] private Transform weapon;
    [SerializeField] private Transform firePosition;

    private float timeElapced;
    private float timeIntervalToFire = 2;

    private void Update()
    {
        timeElapced += Time.deltaTime;
        if(timeElapced >= timeIntervalToFire)
        {
            timeElapced = 0;
            enemyController.Fire(firePosition);
        }

        if(transform.position.x >= 11)
        {
            Destroy(gameObject);
        }

        enemyController.Move();
        enemyController.RotateWeapon(weapon);
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

}
