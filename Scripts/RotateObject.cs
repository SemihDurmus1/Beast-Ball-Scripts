using UnityEngine;

public class RotateObject : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 180f * Time.deltaTime);
    }
}
