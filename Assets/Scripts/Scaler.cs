using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private FloatVariable momentOfInertiaX;
    [SerializeField] private FloatVariable momentOfInertiaY;
    [SerializeField] private FloatVariable momentOfInertiaZ;


    private void Start()
    {
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

    void UpdateValues(float ctx)
    {
        transform.localScale = 0.2f*ScaleWhithMomentOfInertia();
    }
    Vector3 ScaleWhithMomentOfInertia() 
    {
        float x = Mathf.Sqrt(6 * momentOfInertiaY.Value) + Mathf.Sqrt(6 * momentOfInertiaZ.Value);
        float y = Mathf.Sqrt(6 * momentOfInertiaX.Value) + Mathf.Sqrt(6 * momentOfInertiaZ.Value);
        float z = Mathf.Sqrt(6 * momentOfInertiaY.Value) + Mathf.Sqrt(6 * momentOfInertiaX.Value);
        return new Vector3(x, y, z);
    }
}
