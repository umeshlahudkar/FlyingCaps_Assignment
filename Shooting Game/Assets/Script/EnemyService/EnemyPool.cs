using UnityEngine;

public class EnemyPool : ObjectPool<EnemyController>
{
    private EnemyView enemyPrefab;
    private Vector2 spwanPosition;
    private EnemyService enemyService;

    public EnemyController GetItem(EnemyView enemyPrefab, Vector2 spwanPosition, EnemyService enemyService)
    {
        this.enemyPrefab = enemyPrefab;
        this.spwanPosition = spwanPosition;
        this.enemyService = enemyService;

        return GetItem();
    }

    public override EnemyController CreateNew()
    {
        EnemyController enemyController = new EnemyController(enemyPrefab, spwanPosition, enemyService);
        return enemyController;
    }
}
