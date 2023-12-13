using System.Collections;
using UnityEngine;

namespace Game.Interactable
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Renderer goldRenderer;
        [SerializeField] private float delayToDisolved;
        [SerializeField] private float speedDisolved;

        private bool isUsed;
        private Collider chestCollider;

        private void Start()
        {
            chestCollider = GetComponent<Collider>();
        }

        public void Action()
        {
            isUsed = true;
            anim.SetTrigger("Open");
            StartCoroutine(GoldDisabled());
        }

        public bool CanUse()
        {
            return !isUsed;
        }

        private IEnumerator GoldDisabled()
        {
            yield return new WaitForSeconds(delayToDisolved);
            Material material = goldRenderer.material;
            float disolveValue = material.GetFloat("_Alfa");

            while(disolveValue < 1)
            {
                disolveValue += speedDisolved * Time.deltaTime;
                material.SetFloat("_Alfa", disolveValue);
                yield return null;
            }

            chestCollider.enabled = false;
        }
    }
}