using Shooter.SO;

namespace Shooter.EnemyService
{
    public class EnemyModel
    {
        public float movementSpeed { get; private set; }
        public float weaponRotationSpeed { get; private set; }
        public float timeBetweenFire { get; private set; }
        public float bulletLaunchForce { get; private set; }
        public float health { get; private set; }
        public float healthBarActiveTime { get; private set; }

        public EnemyModel(EnemySO enemySO)
        {
            movementSpeed = enemySO.movementSpeed;
            weaponRotationSpeed = enemySO.weaponRotationSpeed;
            timeBetweenFire = enemySO.timeBetweenFire;
            bulletLaunchForce = enemySO.bulletLaunchForce;
            health = enemySO.health;
            healthBarActiveTime = enemySO.healthBarActiveTime;
        }
    }
}
