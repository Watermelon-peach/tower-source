using Tower.Player;
using UnityEngine;

public class AttackDR : MonoBehaviour
{
    //public AK.Wwise.Event CHA_DL_Attack01;
    //public AK.Wwise.Event CHA_DL_Attack02;
    //public AK.Wwise.Event CHA_DL_Attack03;
    //public AK.Wwise.Event CHA_DL_AttackSkill01;

    //public AK.Wwise.Event CHA_DL_HitAttack01;
    //public AK.Wwise.Event CHA_DL_HitAttack02;
    //public AK.Wwise.Event CHA_DL_HitAttack03;
    //public AK.Wwise.Event CHA_DL_HitSkill01;

    //public AK.Wwise.Event CHA_DL_TakeDamage_Voice;

    //public AK.Wwise.Event CHA_DL_Death01;
    //public AK.Wwise.Event CHA_DL_DeathVoice;

    //public AK.Wwise.Event Cha_DR_Dash;
    //public AK.Wwise.Event Cha_DR_Dash_Voice;



    public EnemyDetector detector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnAttack01()
    {
        if (detector.detectedEnemies.Count <= 0)
        {
            //CHA_DL_Attack01?.Post(gameObject);
        }
        else
        {
            //CHA_DL_HitAttack01?.Post(gameObject);
        }
    }

    public void OnAttack02()
    {
        if (detector.detectedEnemies.Count <= 0)
        {
            //CHA_DL_Attack02?.Post(gameObject);
        }
        else
        {
            //CHA_DL_HitAttack02?.Post(gameObject);
        }
    }

    public void OnAttack03()
    {
        if (detector.detectedEnemies.Count <= 0)
        {
            //CHA_DL_Attack03?.Post(gameObject);
        }
        else
        {
            //CHA_DL_HitAttack03?.Post(gameObject);
        }
    }

    public void OnAttackSkill()
    {
        if (detector.detectedEnemies.Count <= 0)
        {
            //CHA_DL_AttackSkill01?.Post(gameObject);
        }
        else
        {
            //CHA_DL_HitSkill01?.Post(gameObject);
        }
    }

    public void DL_TakeDamage_Voice()
    {
        //CHA_DL_TakeDamage_Voice.Post(gameObject);
    }

    public void DL_Dash()
    {
        //Cha_DR_Dash.Post(gameObject);
        //Cha_DR_Dash_Voice.Post(gameObject);
    }

    public void DL_Death()
    {
        //CHA_DL_Death01.Post(gameObject);
        //CHA_DL_DeathVoice.Post(gameObject);
    }


}
