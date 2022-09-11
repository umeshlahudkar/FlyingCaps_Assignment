using UnityEngine;
using Shooter.Global;
using Shooter.SO;

namespace Shooter.EnemyService
{
    public class EnemyPool : ObjectPool<EnemyController>
    {
        private EnemySO enemySO;
        private Vector2 spwanPosition;
        private EnemyService enemyService;

        public EnemyController GetItem(EnemySO enemySO, Vector2 spwanPosition, EnemyService enemyService)
        {
            this.enemySO = enemySO;
            this.spwanPosition = spwanPosition;
            this.enemyService = enemyService;

            return GetItem();
        }

        public override EnemyController CreateNew()
        {
            EnemyController enemyController = new EnemyController(enemySO, spwanPosition, enemyService);
            return enemyController;
        }
    }
}
