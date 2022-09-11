using System;
using Shooter.Global;

namespace Shooter.Event
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action OnEnemyKilled;
        public event Action OnTowerDestroy;
        public event Action OnLevelFailed;
        public event Action OnReplayButtonClick;
        public event Action OnLevelComplete;
        public event Action OnNewLevelStart;

        public void InvokeOnEnemyKilledEvent()
        {
            OnEnemyKilled?.Invoke();
        }

        public void InvokeOnTowerDestroyEvent()
        {
            OnTowerDestroy?.Invoke();
        }

        public void InvokeOnLevelFailedEvent()
        {
            OnLevelFailed?.Invoke();
        }

        public void InvokeOnReplayButtonClickEvent()
        {
            OnReplayButtonClick?.Invoke();
        }

        public void InvokeOnLevelCompleteEvent()
        {
            OnLevelComplete?.Invoke();
        }

        public void InvokeOnNewLevelStartEvent()
        {
            OnNewLevelStart?.Invoke();
        }
    }
}

