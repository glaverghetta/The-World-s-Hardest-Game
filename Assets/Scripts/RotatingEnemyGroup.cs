using UnityEngine;

public class RotatingEnemyGroup : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float rotationDir = 1f;  // positive = counterlockwise, negative = clockwise

    void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed * rotationDir * Time.deltaTime);
    }

}
