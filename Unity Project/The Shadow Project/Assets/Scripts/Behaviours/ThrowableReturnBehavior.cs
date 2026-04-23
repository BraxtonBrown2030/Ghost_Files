using UnityEngine;

public class ThrowableReturnBehavior : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private Transform target;

    [Header("Components")]
    [SerializeField] private ThrowObjectBehavior throwObjectManager;

    [Header("Wwise Event")]
    [SerializeField] public AK.Wwise.Event playerDeflect;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log('1');
        if (other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            Debug.Log('2');
            if (objectBehaviour.thrown == true && objectBehaviour.returnable == true)
            {
                Debug.Log('3');
                // End Current Throw
                throwObjectManager.EndThrow(objectBehaviour.gameObject);
                Debug.Log('4');
                // Start Return Throw
                objectBehaviour.returned = true;
                throwObjectManager.StartPlayerThrow(objectBehaviour.gameObject, target.position, objectBehaviour.throwSpeed);
                Debug.Log('5');
                //Wwise Audio Trigger
                playerDeflect.Post(gameObject);
                Debug.Log('6');
            }
        }
    }


}
