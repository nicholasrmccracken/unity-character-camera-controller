using System;
using UnityEngine;

namespace McCrackenNicholas.Lab1
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance {get; private set; }

        public event Action<Transform> OnCharacterUpdated;

        [SerializeField] private Transform activeCharacter;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else
            {
                Destroy(gameObject);
            }
        }

        public void SetActiveCharacter(Transform newCharacter)
        {
            activeCharacter = newCharacter;
            OnCharacterUpdated?.Invoke(activeCharacter);
        }

        public Transform GetActiveCharacter()
        {
            return activeCharacter;
        }
    }
}
