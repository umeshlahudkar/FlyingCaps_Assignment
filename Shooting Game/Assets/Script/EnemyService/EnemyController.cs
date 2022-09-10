using UnityEngine;

public class EnemyController 
{
    private EnemyView enemyView;
    private Transform target = null;
    private EnemyService enemyService;
    private CharacterType characterType = CharacterType.Enemy;

    public EnemyController(EnemyView enemyPrefab, Vector2 spwanPosition, EnemyService enemyService)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemyPrefab, spwanPosition, Quaternion.identity);
        enemyView.SetEnemyController(this);
        this.enemyService = enemyService;
    }

    public void Enable(Vector2 spwanPosition)
    {
        enemyView.transform.position = spwanPosition;
        enemyView.gameObject.SetActive(true);
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void Move()
    {
        enemyView.transform.Translate(Vector2.right * Time.deltaTime);
    }

    public void RotateWeapon(Transform weapon)
    {
        if(target != null)
        {
            Vector2 direction = (target.position - weapon.position).normalized;
            Quaternion lookTowards = Quaternion.LookRotation(Vector3.forward, direction);
            weapon.localRotation = Quaternion.Slerp(weapon.rotation, lookTowards, Time.deltaTime);
        }
    }

    public void Fire(Transform firePosition)
    {
        BulletService.Instance.GetBullet(firePosition, 10, characterType);
    }

    public CharacterType GetCharacterType()
    {
        return characterType;
    }

    public void Disable()
    {
        enemyView.gameObject.SetActive(false);
        enemyService.ReturnToPool(this);
        EventService.Instance.InvokeOnEnemyKilledEvent();
    }
}
