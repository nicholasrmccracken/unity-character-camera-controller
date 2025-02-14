using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class UpdateCameraHandler
    {
        public UpdateCameraHandler(InputAction cameraSwitchAction, CameraSwitcher cameraSwitcher)
        {
            cameraSwitchAction.performed += cameraSwitcher.NextCamera;
            cameraSwitchAction.Enable();
        }
    }
}
