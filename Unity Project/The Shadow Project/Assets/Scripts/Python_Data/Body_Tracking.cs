using UnityEngine;
using System.Collections.Generic;
public class Body_Tracking : MonoBehaviour
{   
    public UDP udpBody;
    public List<GameObject> bodyPoints = new List<GameObject>();
    public float trackingDiv = 100;
    
    
    private void FixedUpdate()
    {
        string data = udpBody.data;
        if (string.IsNullOrEmpty(data)) return;

        data = data.Trim(new char[] { '[', ']' });
        string[] values = data.Split(',');
        
        for (int i = 0; i < bodyPoints.Count; i++)
        {  
            float x = 7 - float.Parse(values[i * 2]) / trackingDiv;
            float y = float.Parse(values[i * 2 + 1]) / trackingDiv; // try minus by 4 if position not working right

            bodyPoints[i].transform.localPosition = new Vector3(x, y, bodyPoints[i].transform.localPosition.z);
        }
    }
}
