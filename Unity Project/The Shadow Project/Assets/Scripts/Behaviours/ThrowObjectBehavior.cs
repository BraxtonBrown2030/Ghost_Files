/*
Originial Coder: Zackery E.
Recent Coder: Zackery E.
Recent Changes: Initial Coding
Last date worked on: 9/29/2025
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectBehavior : MonoBehaviour
{

    [Header("Settings")]
    public float overshoot = 3; // How far the object goes past target
    public  Transform handLocation;

    public Dictionary<GameObject, Coroutine> currentThrows = new Dictionary<GameObject, Coroutine>();

    public void StartThrow(GameObject throwable, Vector3 location, float speed)
    {
		Debug.Log("This didn't help1");
        if (currentThrows.TryGetValue(throwable, out Coroutine existing))
        {
			Debug.Log("This didn't help2");
            StopCoroutine(existing);
            currentThrows.Remove(throwable);
			Debug.Log("This didn't help3");
        }

		ResetObjectBehaviour resetBehaviour = throwable.GetComponent<ResetObjectBehaviour>();
		resetBehaviour.StartTimeDestroy();
		Debug.Log("This didn't help4");

        Coroutine newThrow = StartCoroutine(MoveOverTime(throwable, location, speed));
        currentThrows[throwable] = newThrow;
		Debug.Log("This didn't help5");
    }

	public void StartPlayerThrow(GameObject throwable, Vector3 location, float speed)
    {
		Debug.Log("Player got skills");
        if (currentThrows.TryGetValue(throwable, out Coroutine existing))
        {
            StopCoroutine(existing);
            currentThrows.Remove(throwable);
			Debug.Log("Stopped a coroutine");
        }
		ResetObjectBehaviour resetBehaviour = throwable.GetComponent<ResetObjectBehaviour>();
		resetBehaviour.StartTimeDestroy();
		Debug.Log("7");
        Coroutine newThrow = StartCoroutine(PlayerMoveOverTime(throwable, location, speed));
	
        currentThrows[throwable] = newThrow;
		Debug.Log("8");
    }

    public void Levitate(GameObject throwable, float speed)
    {
        
        
        Coroutine newThrow = StartCoroutine(MoveOverTimeLev(throwable, handLocation.position, speed));
        
    }
    public void EndThrow(GameObject throwable)
    {
        if (currentThrows.TryGetValue(throwable, out Coroutine throwRoutine))
        {
            StopCoroutine(throwRoutine);
            currentThrows.Remove(throwable);   
        }
    }

    public IEnumerator MoveOverTime(GameObject throwable, Vector3 location, float speed)
    {
	Debug.Log("ghost be throwing");
        yield return new WaitForSeconds(0.75f);
        Vector3 dir = (location - throwable.transform.position).normalized;
        Vector3 overShootTarget = location + dir * overshoot;

        while (throwable != null && Vector3.Distance(throwable.transform.position, overShootTarget) > 0.01f)
        {
			//Debug.Log("moving2" + throwable.name);
            throwable.transform.position = Vector3.MoveTowards(
                throwable.transform.position,
                overShootTarget,
                speed * Time.deltaTime
            );

            yield return null;
        }

        // snap to end
        if (throwable != null){ throwable.transform.position = overShootTarget; }

        currentThrows.Remove(throwable);
		Debug.Log("Culprit?");
		
    }

	public IEnumerator PlayerMoveOverTime(GameObject throwable, Vector3 location, float speed)
    {
		Debug.Log("Start Pos: " + throwable.transform.position);
Debug.Log("Target Pos: " + location);
Debug.Log("Distance: " + Vector3.Distance(throwable.transform.position, location));
        //Vector3 dir = (location - throwable.transform.position).normalized;
		Debug.Log("10");
        //Vector3 overShootTarget = location + dir * overshoot;
		//Debug.Log("11 " + dir + location + overshoot);
        while (throwable != null )
        {
			//Debug.Log("Moving " + throwable.name);
            throwable.transform.position = Vector3.MoveTowards(
                throwable.transform.position,
                location,
                speed * Time.deltaTime
            );

            yield return null;
        }
		Debug.Log("12");
        // snap to end
        //if (throwable != null){ throwable.transform.position = overShootTarget; }

        currentThrows.Remove(throwable);
		Debug.Log("13");
    }
    
    public IEnumerator MoveOverTimeLev(GameObject throwable, Vector3 location, float speed)
    {
        yield return new WaitForSeconds(1);
        Vector3 dir = (location - throwable.transform.position).normalized;
        while (throwable != null && Vector3.Distance(throwable.transform.position, location) > 0.3f)
        {

            throwable.transform.position = Vector3.MoveTowards(
                throwable.transform.position,
                location,
                speed * Time.deltaTime
            );
            //Debug.Log(Vector3.Distance(throwable.transform.position, location));
            yield return null;
        }

        // snap to end
        if (throwable != null){ throwable.transform.position = location; }

        currentThrows.Remove(throwable);
        Debug.Log("We're outta here");
    }
}
