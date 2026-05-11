using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] private  FloatVariable momentOfInertiaX;
    [SerializeField] private FloatVariable momentOfInertiaY;
    [SerializeField] private FloatVariable momentOfInertiaZ;

    [SerializeField] private FloatVariable speedX;
    [SerializeField] private FloatVariable speedY;
    [SerializeField] private FloatVariable speedZ;
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        momentOfInertiaX.OnReset();
        momentOfInertiaY.OnReset();
        momentOfInertiaZ.OnReset();
    }
}
