using UnityEngine;
using Shooter.TowerSevice;

namespace Shooter.SO
{
    [CreateAssetMenu(fileName = "TowerSO", menuName = "Scriptable Object/Tower")]
    public class TowerSO : ScriptableObject
    {
        public float timeBetweenFire;
        public float bulletLaunchForce;
        public float weaponRotationSpeed;
        public float health;
        public float healthBarActiveTime;
        public Tower tower;
    }
}


