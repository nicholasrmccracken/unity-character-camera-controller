using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class PlayerRespawner : BaseCharacterUpdater
    {
        [SerializeField] private float respawnHeightAboveGround = 5f;
        [SerializeField] private float respawnDelay = 1.5f;
        [SerializeField] private float fallHeightThreshold = -1f;

        private Vector3 initialPosition;
        private Quaternion initialRotation;
        private Rigidbody playerRigidbody;
        private bool isRespawning = false;
        
        void Start()
        {
            initialPosition = player.transform.position;
            initialRotation = player.transform.rotation;
            playerRigidbody = player.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (isRespawning || player.transform.position.y >= fallHeightThreshold) return;
            StartCoroutine(RespawnWithDelay());
        }

        private IEnumerator RespawnWithDelay()
        {
            isRespawning = true;
            yield return new WaitForSeconds(respawnDelay);
            ResetPlayerPosition();
            isRespawning = false;
        }

        public void Respawn(InputAction.CallbackContext obj)
        {
            if (isRespawning) return;
            isRespawning = true;
            ResetPlayerPosition();
            isRespawning = false;
        }

        private void ResetPlayerPosition()
        {
            Vector3 respawnPosition = initialPosition + Vector3.up * respawnHeightAboveGround;
            player.transform.SetPositionAndRotation(respawnPosition, initialRotation);
            playerRigidbody.linearVelocity = Vector3.zero; 
        }
    }
}
