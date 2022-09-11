using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPooler;
    [SerializeField] private EnemyView enemyPrefab;
    [SerializeField] private GameObject[] targetTowers;

    private List<EnemyController> enemyControllersHolder = new List<EnemyController>();
    private Transform target;
    private int index = 0;

    private void OnEnable()
    {
        target = targetTowers[index].transform;
        EventService.Instance.OnTowerDestroy += UpdateEnemyTarget;
    }

    private void Start()
    {
        StartCoroutine(SpwanEnemy());
    }

    private void UpdateEnemyTarget()
    {
        index++;
        if(index >= targetTowers.Length)
        {
            index = 0;
        }

        if(targetTowers[index] != null)
        {
            target = targetTowers[index].transform;
        }

        for (int i = 0; i < enemyControllersHolder.Count; i++)
        {
            enemyControllersHolder[i].UpdateTarget(target);
        }
    }

    IEnumerator SpwanEnemy()
    {
        while(true)
        {
            InstantiateEnemy();
            yield return new WaitForSeconds(5);
        }
    }

    private void InstantiateEnemy()
    {
        Vector2 position = new Vector2(-11f, Random.Range(1.6f, 3.8f));
        EnemyController enemyController = enemyPooler.GetItem(enemyPrefab, position, this);
        enemyController.Enable(position);
        enemyController.UpdateTarget(target);
        enemyControllersHolder.Add(enemyController);
    }

    public void ReturnToPool(EnemyController enemyController)
    {
        enemyPooler.ReturnToPool(enemyController);
        RemoveFromHolder(enemyController);
    }

    private void RemoveFromHolder(EnemyController enemyController)
    {
        for(int i = 0; i < enemyControllersHolder.Count; i++)
        {
            if(enemyControllersHolder[i].Equals(enemyController))
            {
                enemyControllersHolder.RemoveAt(i);
            }
        }
    }

    private void OnDisable()
    {
        EventService.Instance.OnTowerDestroy -= UpdateEnemyTarget;
    }

}
