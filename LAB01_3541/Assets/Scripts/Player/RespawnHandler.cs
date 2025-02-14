using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class RespawnHandler
    {
        public RespawnHandler(InputAction respawnAction, PlayerRespawner playerRespawner)
        {
            respawnAction.performed += playerRespawner.Respawn;
            respawnAction.Enable();
        }
    }
}
