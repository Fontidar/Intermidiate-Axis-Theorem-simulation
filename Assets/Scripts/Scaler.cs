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
        transform.localScale = 0.2f * new Vector3(momentOfInertiaX.Value, momentOfInertiaY.Value, momentOfInertiaZ.Value);;
    }
}
