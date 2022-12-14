using UnityEngine;
using Shooter.Interface;

namespace Shooter.BulletSevice
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        [SerializeField] private Rigidbody2D rb2D;

        private float timeElapced;

        private void Update()
        {
            timeElapced += Time.deltaTime;
            if (timeElapced >= bulletController.bulletModel.timeToDisable)
            {
                timeElapced = 0;
                bulletController.Disable();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            timeElapced = 0;
            IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
            if (damageble != null && damageble.GetCharacterType() != bulletController.characterType)
            {
                damageble.TakeDamage(bulletController.bulletModel.bulletDamage);
            }

            bulletController.Disable();
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rb2D;
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }
    }
}
