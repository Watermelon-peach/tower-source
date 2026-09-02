using UnityEngine;

public class BGM : MonoBehaviour
{
    //public AK.Wwise.State OntriggerEnterState01;
    //public AK.Wwise.State OntriggerExitState01;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            //OntriggerEnterState01.SetValue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            //OntriggerExitState01.SetValue();
        }
    }

}