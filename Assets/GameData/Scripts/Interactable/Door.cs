using System.Collections;
using UnityEngine;

namespace Game.Interactable
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform doorLeaf;
        [SerializeField] private float speed;

        private bool isOpen;
        private bool isCanUse = true;
        private Coroutine OpenCoroutine;
        public void Action()
        {
            if (!isOpen && OpenCoroutine == null)
                OpenCoroutine = StartCoroutine(Open());
            else if (OpenCoroutine == null)
                OpenCoroutine = StartCoroutine(Close());
        }

        private IEnumerator Open()
        {
            isCanUse = false;
            while (doorLeaf.localRotation.y > -0.5)
            {
                doorLeaf.Rotate(Vector3.back * Time.deltaTime * speed);
                yield return new WaitForFixedUpdate();
            }
            isOpen = true;
            OpenCoroutine = null;
            isCanUse = true;
        }

        private IEnumerator Close()
        {
            isCanUse = false;
            while (doorLeaf.localRotation.y < 0)
            {
                doorLeaf.Rotate(Vector3.forward * Time.deltaTime * speed);
                yield return new WaitForFixedUpdate();
            }
            isOpen = false;
            OpenCoroutine = null;
            isCanUse = true;
        }

        public bool CanUse()
        {
            return isCanUse;
        }
    }
}