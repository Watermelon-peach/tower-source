using UnityEngine;

/// <summary>
/// 적 때죽맞
/// </summary>
public class MonsterAttack : MonoBehaviour
{
    #region Variables
    //public AK.Wwise.Event AttackSound;
    //public AK.Wwise.Event DeathSound;
    //public AK.Wwise.Event DeathWithClothSound;
    //public AK.Wwise.Event HitSound;
    #endregion

    public void OnAttack()
    {
        //AttackSound?.Post(gameObject);
    }

    public void OnDeath()
    {
        //DeathSound?.Post(gameObject);
        //DeathWithClothSound?.Post(gameObject);
    }

    public void OnHit()
    {
        //HitSound?.Post(gameObject);
    }
}
