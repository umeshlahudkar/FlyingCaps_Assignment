using UnityEngine;

public class EnemyView : MonoBehaviour, IDamageble
{
    private EnemyController enemyController;
    [SerializeField] private HealthController healthController;
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
            Disable();
        }

        enemyController.Move();
        enemyController.RotateWeapon(weapon);
    }

    public void Disable()
    {
        enemyController.Disable();
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void TakeDamage(int damage)
    {
        healthController.TakeDamage(damage);
    }

    public CharacterType GetCharacterType()
    {
        return enemyController.GetCharacterType();
    }
}
