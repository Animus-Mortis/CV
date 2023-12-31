using Game.UI;
using UnityEngine;

namespace Game.Player
{
    public class IneractableCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask InetactableLayer;
        [SerializeField] private float rayLength;

        private InteractableImageViewer imageViewer;
        private IInteractable target;

        private void Update()
        {
            CheckTarget();

            if (Input.GetButtonDown("Use")
                && target != null
                && target.CanUse())
            {
                target.Action();
            }
        }

        public void SetInteractableImage(InteractableImageViewer imageViewer)
        {
            this.imageViewer = imageViewer;
        }

        private void CheckTarget()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.red, rayLength);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, InetactableLayer))
            {
                target = hit.transform.GetComponent<IInteractable>();
                if (target.CanUse())
                    imageViewer.ActivateInteractableImage(true);
                else
                    imageViewer.ActivateInteractableImage(false);
            }
            else
            {
                target = null;
                imageViewer?.ActivateInteractableImage(false);
            }
        }
    }
}