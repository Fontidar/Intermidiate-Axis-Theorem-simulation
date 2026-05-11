using UnityEngine;

public class DropDown_Menu : MonoBehaviour
{
    [SerializeField] private GameObject sub_menu;

    public void ToggleMenu()
    {
        if (sub_menu != null) sub_menu.SetActive(!sub_menu.activeSelf);
    }

}
