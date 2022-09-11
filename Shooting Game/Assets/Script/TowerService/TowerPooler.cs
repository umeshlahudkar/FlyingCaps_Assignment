using UnityEngine;
using Shooter.Global;
using Shooter.SO;

namespace Shooter.TowerSevice
{
    public class TowerPooler : ObjectPool<TowerController>
    {
        private TowerSO towerSO;
        private Transform cursorPosition;
        private TowerService towerService;


        public TowerController GetItem(TowerSO towerSO, Transform cursorPosition, TowerService towerService)
        {
            this.towerSO = towerSO;
            this.cursorPosition = cursorPosition;
            this.towerService = towerService;

            return GetItem();
        }

        public override TowerController CreateNew()
        {
            TowerController towerController = new TowerController(towerSO, cursorPosition, towerService);
            return towerController;
        }
    }
}

