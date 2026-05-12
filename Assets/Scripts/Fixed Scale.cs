using UnityEngine;

public class FixedScale : MonoBehaviour
{
    private Vector3 scale;

    private void Awake()
    {
        scale= transform.localScale;
    }
    void LateUpdate()
    {
       transform.localScale = new Vector3 (scale.x/transform.parent.lossyScale.x, scale.y / transform.parent.lossyScale.y, scale.z / transform.parent.lossyScale.z);
    }

}
