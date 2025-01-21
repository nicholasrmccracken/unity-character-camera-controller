using UnityEngine;
using McCrackenNicholas.Input;
using UnityEngine.TextCore;

namespace McCrackenNicholas.Lab1
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private CameraSwitcher cameraSwitcher;
        [SerializeField] private CharacterSwitcher characterSwitcher;
        [SerializeField] private MovementControl movementController;
        [SerializeField] private PlayerRespawner playerRespawner;
        private PlayerInputActions inputScheme;
        private RespawnHandler respawnHandler;
        
        private void Awake()
        {
            inputScheme = new PlayerInputActions();
            movementController.Initialize(inputScheme.Player.Move);
            respawnHandler = new RespawnHandler(inputScheme.Player.Reset, playerRespawner);
        }

        private void OnEnable()
        {
            _ = new UpdateCameraHandler(inputScheme.Player.CameraSwitch, this.cameraSwitcher);
            _ = new UpdateCharacterHandler(inputScheme.Player.PrevCharacter, inputScheme.Player.NextCharacter, this.characterSwitcher);
            _ = new QuitHandler(inputScheme.Player.Quit);
        }
    }
}
