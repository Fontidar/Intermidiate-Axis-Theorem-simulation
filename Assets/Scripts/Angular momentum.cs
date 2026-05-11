using System.Collections.Generic;
using UnityEngine;

public class Angularmomentum : MonoBehaviour
{
    [SerializeField] private FloatVariable momentOfInertiaX;
    [SerializeField] private FloatVariable momentOfInertiaY;
    [SerializeField] private FloatVariable momentOfInertiaZ;
    [SerializeField] private FloatVariable startAngularSpeedX;
    [SerializeField] private FloatVariable startAngularSpeedY;
    [SerializeField] private FloatVariable startAngularSpeedZ;

    private Vector3 momentOfInertia;
    private Vector3 angularSpeed;

    private Rigidbody rb;

    private void Start()
    {

        angularSpeed = new Vector3(startAngularSpeedX.Value, startAngularSpeedY.Value, startAngularSpeedZ.Value);
        rb = GetComponent<Rigidbody>();
        momentOfInertiaX.OnValueChange += UpdateValues;
        momentOfInertiaY.OnValueChange += UpdateValues;
        momentOfInertiaZ.OnValueChange += UpdateValues;
        UpdateValues(float.NaN);
    }
    private void OnDestroy()
    {
        momentOfInertiaX.OnValueChange -= UpdateValues;
        momentOfInertiaY.OnValueChange -= UpdateValues;
        momentOfInertiaZ.OnValueChange -= UpdateValues;
    }

    private void FixedUpdate()
    {
        Vector3 n = RungeKutta_4(angularSpeed, AngularAcceleration, Time.deltaTime);
        rb.angularVelocity = transform.TransformDirection(n);
        angularSpeed = n; 
    }

    private Vector3 RungeKutta_4(Vector3 variable, System.Func<Vector3, Vector3> function_f,float h)
    {
        Vector3 k1 = function_f(variable);
        Vector3 k2 = function_f(variable + h / 2 * k1);
        Vector3 k3 = function_f(variable+h/2*k2);
        Vector3 k4 = function_f(variable + h* k3);
        return variable + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
    }

    private Vector3 AngularAcceleration(Vector3 angularSpeed)
    {
        Vector3 acceleration= Vector3.zero;
        for (int n=0; n<3; n++)
        {
            int idx0 = n;
            int idx1 = (n + 1) % 3;
            int idx2 = (n + 2) % 3;
            acceleration[n]= ((momentOfInertia[idx1] - momentOfInertia[idx2])/ momentOfInertia[idx0]) * angularSpeed[idx2] * angularSpeed[idx1];
        }
        return acceleration;
    }
    private void UpdateValues(float ctx)
    {
        momentOfInertia = new Vector3(momentOfInertiaX.Value, momentOfInertiaY.Value, momentOfInertiaZ.Value);
    }
}
