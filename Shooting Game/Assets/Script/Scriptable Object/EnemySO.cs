using UnityEngine;
using Shooter.EnemyService;

namespace Shooter.SO
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Object/Enemy")]
    public class EnemySO : ScriptableObject
    {
        public float timeBetweenFire;
        public float bulletLaunchForce;
        public float movementSpeed;
        public float weaponRotationSpeed;
        public float health;
        public float healthBarActiveTime;
        public EnemyView enemyPrefab;
    }
}


