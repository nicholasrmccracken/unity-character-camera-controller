using UnityEngine;
using UnityEngine.InputSystem;

namespace McCrackenNicholas.Lab1
{
    public class CharacterSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] characters;
        private int index = 0;

        void Start()
        {
            Transform activeCharacter = CharacterManager.Instance.GetActiveCharacter();
            index = System.Array.IndexOf(characters, activeCharacter.gameObject);
            CharacterManager.Instance.SetActiveCharacter(characters[index].transform);
        }

        public void PrevCharacter(InputAction.CallbackContext context)
        {
            int prevIndex = (index - 1 + characters.Length) % characters.Length;
            UpdateCharacter(prevIndex);
        }
        
        public void NextCharacter(InputAction.CallbackContext context)
        {
            int nextIndex = (index + 1) % characters.Length;
            UpdateCharacter(nextIndex);
        }

        private void UpdateCharacter(int updatedIndex)
        {
            CharacterManager.Instance.SetActiveCharacter(characters[updatedIndex].transform);
            index = updatedIndex;
        }
    }
}
