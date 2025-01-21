using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class CameraSwitcher : BaseCharacterUpdater
    {
        [SerializeField] private Camera[] cameras;
        [SerializeField] private Camera defaultCamera;
        private int index = 0;

        void Start()
        {            
            foreach (Camera cam in cameras)
            {
                cam.gameObject.SetActive(false);
            }
            defaultCamera.gameObject.SetActive(true);

            index = System.Array.IndexOf(cameras, defaultCamera);
        }
        
        public void NextCamera(InputAction.CallbackContext context)
        {
            int nextIndex = (index + 1) % cameras.Length;
            cameras[nextIndex].gameObject.SetActive(true);
            cameras[index].gameObject.SetActive(false);
            index = nextIndex;
        }

        protected override void UpdatePlayer(Transform newCharacter)
        {
            player = newCharacter.gameObject;
            UpdateCameraTargets();
        }

        private void UpdateCameraTargets()
        {
            foreach (Camera cam in cameras)
            {
                FollowWithOffset followScript = cam.GetComponent<FollowWithOffset>();
                followScript.SetTarget(player.transform);
            }
        }
    }
}
