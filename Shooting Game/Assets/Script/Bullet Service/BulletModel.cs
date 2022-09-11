using Shooter.SO;

namespace Shooter.BulletSevice
{
    public class BulletModel
    {
        public float timeToDisable { get; private set; }
        public float bulletDamage { get; private set; }

        public BulletModel(BulletSO bulletSO)
        {
            timeToDisable = bulletSO.timeToDisable;
            bulletDamage = bulletSO.bulletDamage;
        }
    }
}
