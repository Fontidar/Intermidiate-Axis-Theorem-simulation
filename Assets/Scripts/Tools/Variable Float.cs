using System;
using UnityEngine;

//Crea una opción de generar una nueva variable de este tipo en el inspector
[CreateAssetMenu(menuName = "Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    //Variables de diseño
    [Header("Variable de diseño (no tocar)")]
    [SerializeField] private float _onStartValue;
    [SerializeField] private float _onStartMin = float.NegativeInfinity;
    [SerializeField] private float _onStartMax = float.PositiveInfinity;
    [SerializeField] private float _changeThreshold; 
    private float _minValue;
    private float _maxValue;
    

    //Valor de mi Float
    [Header("Valor dinamico")]
    [SerializeField] private float _value;

    //Eventos a los que se pueden suscribir
    public event Action<float> OnValueChange;
    public event Action<float> OnPercentageChange;

    public float Value
    {
        get { return _value; }
        set 
        { 
            float newF = Mathf.Clamp(value,_minValue,_maxValue);

            if (Mathf.Abs(newF - _value) < _changeThreshold) return;

            _value = newF;

            NotifyValueChange();
            NotifyPercentageChange();
        }
    }

    public float Percentage => (_maxValue - _minValue > 0)
    ? (_value - _minValue) / (_maxValue - _minValue)
    : 0f;

    private void NotifyValueChange() => OnValueChange?.Invoke(_value);

    private void NotifyPercentageChange() => OnPercentageChange?.Invoke(Percentage);

    private void OnEnable()
    {
        _value=_onStartValue;
        _minValue=_onStartMin ;
        _maxValue=_onStartMax ;

        OnValueChange?.Invoke(_value);
        OnPercentageChange?.Invoke(Percentage);
    }

    public void OnReset()
    {
        _value = _onStartValue;
        _minValue = _onStartMin;
        _maxValue = _onStartMax;
        OnValueChange?.Invoke(_value);
        OnPercentageChange?.Invoke(Percentage);
    }

    public void ChangeMin(float newValue)
    {
        _minValue = newValue;
    }

    public void ChangeMax(float newValue,bool changeDiference = false)
    {
        float oldMaxValue = _maxValue;
        _maxValue = newValue;
        if(changeDiference)
        {
            Value += _maxValue - oldMaxValue;
        }
        
    }

    public void Add(float toAdd)
    {
        Value += toAdd;
    }

    public void Substract(float toSubstract)
    {
        Value -= toSubstract;
    }

    public void AddPercentage(float toAdd)
    {
        Value += toAdd * (_maxValue - _minValue);
    }

    public void SubstractPercentage(float toSubstract)
    {
        Value -= toSubstract * (_maxValue - _minValue);
    }
}