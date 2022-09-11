using System;

public class EventService : GenericSingleton<EventService>
{
    public event Action OnEnemyKilled;
    public event Action OnTowerDestroy;

    public void InvokeOnEnemyKilledEvent()
    {
        OnEnemyKilled?.Invoke();
    }

    public void InvokeOnTowerDestroyEvent()
    {
        OnTowerDestroy?.Invoke();
    }
}
