using Shooter.Global;

namespace Shooter.Interface
{
    interface IDamageble
    {
        void TakeDamage(float damage);
        CharacterType GetCharacterType();
        void Disable();
    }
}
