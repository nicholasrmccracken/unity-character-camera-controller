using UnityEngine;

namespace McCrackenNicholas.Lab1
{
    class FollowWithOffset : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        private Transform target;

        private void OnEnable()
        {
            SetTarget(CharacterManager.Instance.GetActiveCharacter());
        }

        private void Update()
        {
            transform.position = target.transform.position + offset;
            transform.LookAt(target.transform);
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}