using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private Transform target;

    private List<EnemyController> enemyControllerList = new List<EnemyController>();

    private int enemyToSpwan = 5;
    private int enemyCount = 0;

    private void Start()
    {
        StartCoroutine(SpwanEnemy());
    }

    IEnumerator SpwanEnemy()
    {
        while(enemyCount <= enemyToSpwan)
        {
            enemyCount++;
            InstantiateEnemy();
            yield return new WaitForSeconds(5);
        }
    }

    public void InstantiateEnemy()
    {
        Vector2 position = new Vector2(-11f, Random.Range(1.6f, 3.8f));
        EnemyController enemyController = new EnemyController(enemyPrefab, position, target, this);
        enemyControllerList.Add(enemyController);
    }
}
