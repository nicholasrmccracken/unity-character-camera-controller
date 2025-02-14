using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class MovementControl : BaseCharacterUpdater
    {
        [SerializeField] private float speed = 5f;
        private InputAction moveAction;
        
        public void Initialize(InputAction moveAction)
        {
           this.moveAction = moveAction;
           this.moveAction.Enable();
        }
        
        private void FixedUpdate()
        {
            Vector2 input = moveAction.ReadValue<Vector2>();
            Vector3 movement = speed * Time.fixedDeltaTime * new Vector3(input.x, 0, input.y);
            player.transform.Translate(movement);
        }
    }
}
