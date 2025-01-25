using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.LowLevel;

public class UIManager : MonoBehaviour
{
    public float button;

    public void UIController(InputAction.CallbackContext context)
    {
        button = context.ReadValue<float>();
    }

    public void Update()
    {
        if (button != 0)
        {
            
        }
    }
}
