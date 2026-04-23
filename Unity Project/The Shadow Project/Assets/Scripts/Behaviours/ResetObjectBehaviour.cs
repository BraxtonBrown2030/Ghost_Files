using UnityEngine;
using System.Collections;

public class ResetObjectBehaviour : MonoBehaviour
{
    public void StartTimeDestroy()
    {
		Debug.Log("Done deal pt.1");	
        StartCoroutine(TimeDestroy());
		Debug.Log("Done deal");
    }
    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(4.0f);
        Reset();

    }
    public void Reset()
    {
        GameObject manager = GameObject.Find("ObjectManager");
        ObjectManager objectManager = manager.GetComponent<ObjectManager>();
        ObjectBehaviour objectBehaviour = this.gameObject.GetComponent<ObjectBehaviour>();
        objectManager.enableSpawnByObject(objectBehaviour);
        objectManager.spawnRandom(1);
        objectManager.spawnedObjects.Remove(objectBehaviour);
        Destroy(this.gameObject);

    }
}
