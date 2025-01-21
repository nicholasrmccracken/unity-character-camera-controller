using NUnit.Framework;
using UnityEngine;

namespace McCrackenNicholas.Lab1
{
    public abstract class BaseCharacterUpdater : MonoBehaviour
    {
        [SerializeField] protected GameObject player;

        protected void OnEnable()
        {
            CharacterManager.Instance.OnCharacterUpdated += UpdatePlayer;
        }

        protected void OnDisable()
        {
            CharacterManager.Instance.OnCharacterUpdated -= UpdatePlayer;
        }

        protected virtual void UpdatePlayer(Transform newCharacter)
        {
            player = newCharacter.gameObject;
        }
    }
}