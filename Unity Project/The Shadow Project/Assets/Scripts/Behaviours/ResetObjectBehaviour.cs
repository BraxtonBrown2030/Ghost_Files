using UnityEngine;
using System.Collections;

public class ResetObjectBehaviour : MonoBehaviour
{
    public void StartTimeDestroy()
    {
		Debug.Log("Done deal pt.1");	
        StartCoroutine(TimeDestroy());
		StartCoroutine(CleanUp());
		Debug.Log("Done deal");
    }
    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(4.0f);
        Reset();

    }

	IEnumerator CleanUp()
	{
		Vector3 location = transform.position;
		yield return new WaitForSeconds(5.0f);
		if (location == transform.position)
		{
			Reset();
		}
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
