using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private FloatVariable xSpeed;
    [SerializeField] private FloatVariable ySpeed;
    [SerializeField] private FloatVariable zSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        xSpeed.Value= rb.angularVelocity.x;
        ySpeed.Value = rb.angularVelocity.y;
        zSpeed.Value = rb.angularVelocity.z;
    }
}
