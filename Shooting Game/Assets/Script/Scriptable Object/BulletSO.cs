using UnityEngine;
using Shooter.BulletSevice;

namespace Shooter.SO
{
    [CreateAssetMenu(fileName = "BulletSO", menuName = "Scriptable Object/Bullet")]
    public class BulletSO : ScriptableObject
    {
        public float timeToDisable;
        public float bulletDamage;
        public BulletView bulletPrefab;
    }

}
