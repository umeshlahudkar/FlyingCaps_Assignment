using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private Transform cursorPosition;
    [SerializeField] private Transform handle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform bulletPosition;

    private float timeElapced;
    private float timeBetweenFire = 1;
    private float launchForce = 10;

    private void Update()
    {
        RotateTowardsTarget();

        timeElapced += Time.deltaTime;

        if(timeElapced >= timeBetweenFire)
        {
            timeElapced = 0;
            Fire();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 direction = (cursorPosition.position - handle.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
        handle.localRotation = Quaternion.Slerp(handle.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void Fire()
    {
        BulletService.Instance.GetBullet(bulletPosition, launchForce);
    }
}
