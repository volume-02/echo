using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Light point;
    void Start()
    {
        point = GetComponentInChildren<Light>();
    }
    public void Check()
    {
        point.enabled = true;
    }
}
