using UnityEngine;

namespace Shooter.SO
{
    [CreateAssetMenu(fileName = "TowerSOList", menuName = "Scriptable Object/TowerSOList")]
    public class TowerSOList : ScriptableObject
    {
        public TowerSO[] towerSOs;
    }
}
