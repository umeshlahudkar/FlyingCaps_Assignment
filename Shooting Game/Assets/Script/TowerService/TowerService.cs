using System.Collections.Generic;
using UnityEngine;
using Shooter.Global;
using Shooter.SO;
using Shooter.Event;

namespace Shooter.TowerSevice
{
    public class TowerService : GenericSingleton<TowerService>
    {
        [SerializeField] private Transform cursorPosition;
        [SerializeField] private TowerPooler towerPooler;
        [SerializeField] private TowerSOList towerSOList;

        private List<TowerController> activeTowers = new List<TowerController>();

        private void OnEnable()
        {
            EventService.Instance.OnReplayButtonClick += CreateTowers;
            EventService.Instance.OnLevelComplete += DisableAllTowers;
            EventService.Instance.OnNewLevelStart += CreateTowers;
        }

        private void Start()
        {
            CreateTowers();
        }

        public void CreateTowers()
        {
            for (int i = 0; i < towerSOList.towerSOs.Length; i++)
            {
                InstantiateTower(towerSOList.towerSOs[i]);
            }
        }

        private void InstantiateTower(TowerSO towerSO)
        {
            TowerController towerController = towerPooler.GetItem(towerSO, cursorPosition, this);
            towerController.Enable();
            activeTowers.Add(towerController);
        }

        public Transform GetActiveTower()
        {
            if (activeTowers.Count > 0)
            {
                return activeTowers[0].towerView.transform;
            }
            return null;
        }

        public void RetuenToPool(TowerController towerController)
        {
            towerPooler.ReturnToPool(towerController);
            RemoveFroemActiveTowerList(towerController);
        }

        private void RemoveFroemActiveTowerList(TowerController towerController)
        {
            if (activeTowers.Count > 0)
            {
                for (int i = 0; i < activeTowers.Count; i++)
                {
                    if (activeTowers[i].Equals(towerController))
                    {
                        activeTowers.RemoveAt(i);
                    }
                }
            }

            if (activeTowers.Count <= 0)
            {
                activeTowers.Clear();
                EventService.Instance.InvokeOnLevelFailedEvent();
            }
        }

        private void DisableAllTowers()
        {
            for (int i = 0; i < activeTowers.Count; i++)
            {
                activeTowers[i].towerView.gameObject.SetActive(false);
                towerPooler.ReturnToPool(activeTowers[i]);
            }
            activeTowers.Clear();
        }

        private void OnDisable()
        {
            EventService.Instance.OnReplayButtonClick -= CreateTowers;
            EventService.Instance.OnNewLevelStart -= CreateTowers;
            EventService.Instance.OnLevelComplete -= DisableAllTowers;
        }
    }

    [System.Serializable]
    public struct Tower
    {
        public TowerView towerPrefab;
        public Vector2 spwanPosition;
    }
}

