using UnityEngine;

[CreateAssetMenu(fileName = "FloatData", menuName = "Scriptable Objects/FloatData")]
public class FloatData : ScriptableObject
{
    public float value;

    public void UpdateValue(float num)
    {
        value += num;
    }

    public void SetValue(float num)
    {
        value = num;
    }
    public void SetValue(FloatData num)
    {
        value = num.value;
    }

    public void CompareValue(FloatData num){
        if (value < num.value) {
            value = num.value;
        }
    }

}
