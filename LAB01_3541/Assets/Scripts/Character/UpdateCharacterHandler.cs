using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class UpdateCharacterHandler
    {
        public UpdateCharacterHandler(InputAction prevCharacterAction, InputAction nextCharacterAction, CharacterSwitcher characterSwitcher)
        {
            prevCharacterAction.performed += characterSwitcher.PrevCharacter;
            prevCharacterAction.Enable();
            nextCharacterAction.performed += characterSwitcher.NextCharacter;
            nextCharacterAction.Enable();
        }
    }
}
