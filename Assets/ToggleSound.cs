using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    public void OnClick(){
        HUDController.Instance.ToggleSound();
    }
}
