using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Global;
using Shooter.SO;
using Shooter.Event;
using Shooter.TowerSevice;

namespace Shooter.EnemyService
{
    public class EnemyService : GenericSingleton<EnemyService>
    {
        [SerializeField] private EnemyPool enemyPooler;
        [SerializeField] private EnemySO enemySO;

        private List<EnemyController> enemyControllersHolder = new List<EnemyController>();
        private Transform target;
        private Coroutine spwanEnemyCoroutine;

        private void OnEnable()
        {
            EventService.Instance.OnTowerDestroy += UpdateEnemyTarget;
            EventService.Instance.OnLevelFailed += DisableAllEnemy;
            EventService.Instance.OnReplayButtonClick += StartSpwaningEnemy;
            EventService.Instance.OnLevelComplete += DisableAllEnemy;
            EventService.Instance.OnNewLevelStart += StartSpwaningEnemy;
        }

        private void Start()
        {
            spwanEnemyCoroutine = StartCoroutine(SpwanEnemy());
        }

        public void StartSpwaningEnemy()
        {
            if (spwanEnemyCoroutine != null)
            {
                StopCoroutine(spwanEnemyCoroutine);
            }
            spwanEnemyCoroutine = StartCoroutine(SpwanEnemy());
        }
        IEnumerator SpwanEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                UpdateEnemyTarget();
                InstantiateEnemy();
                yield return new WaitForSeconds(3);
            }
        }

        private void InstantiateEnemy()
        {
            Vector2 position = new Vector2(-11f, Random.Range(1.6f, 3.8f));
            EnemyController enemyController = enemyPooler.GetItem(enemySO, position, this);
            enemyController.Enable(position);
            enemyController.UpdateTarget(target);
            enemyControllersHolder.Add(enemyController);
        }


        private void UpdateEnemyTarget()
        {
            target = TowerService.Instance.GetActiveTower();

            for (int i = 0; i < enemyControllersHolder.Count; i++)
            {
                enemyControllersHolder[i].UpdateTarget(target);
            }
        }


        public void ReturnToPool(EnemyController enemyController)
        {
            enemyPooler.ReturnToPool(enemyController);
            RemoveFromHolder(enemyController);
        }

        private void RemoveFromHolder(EnemyController enemyController)
        {
            for (int i = 0; i < enemyControllersHolder.Count; i++)
            {
                if (enemyControllersHolder[i].Equals(enemyController))
                {
                    enemyControllersHolder.RemoveAt(i);
                }
            }
        }

        private void DisableAllEnemy()
        {
            StopCoroutine(spwanEnemyCoroutine);
            for (int i = 0; i < enemyControllersHolder.Count; i++)
            {
                enemyControllersHolder[i].enemyView.gameObject.SetActive(false);
                enemyPooler.ReturnToPool(enemyControllersHolder[i]);
            }
            enemyControllersHolder.Clear();
        }

        private void OnDisable()
        {
            EventService.Instance.OnTowerDestroy -= UpdateEnemyTarget;
            EventService.Instance.OnLevelFailed -= DisableAllEnemy;
            EventService.Instance.OnReplayButtonClick -= StartSpwaningEnemy;
            EventService.Instance.OnLevelComplete -= DisableAllEnemy;
            EventService.Instance.OnNewLevelStart -= StartSpwaningEnemy;
        }

    }
}

