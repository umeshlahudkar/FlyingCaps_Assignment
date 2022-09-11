using Shooter.SO;

namespace Shooter.TowerSevice
{
    public class TowerModel
    {
        public float timeBetweenFire { get; private set; }
        public float bulletLaunchForce { get; private set; }
        public float weaponRotationSpeed { get; private set; }

        public float health { get; private set; }
        public float healthBarActiveTime { get; private set; }

        public TowerModel(TowerSO towerSO)
        {
            timeBetweenFire = towerSO.timeBetweenFire;
            bulletLaunchForce = towerSO.bulletLaunchForce;
            weaponRotationSpeed = towerSO.weaponRotationSpeed;
            health = towerSO.health;
            healthBarActiveTime = towerSO.healthBarActiveTime;
        }
    }
}

