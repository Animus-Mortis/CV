using Game.UI;
using UnityEngine;

namespace Game.Player
{
    public class IneractableCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask InetactableLayer;
        [SerializeField] private float rayLength;
        [SerializeField] private InteractableImageViewer imageViewer;

        private IInteractable target;

        private void Update()
        {
            CheckTarget();

            if (Input.GetButtonDown("Use")
                && target != null)
            {
                target.Action();
            }
        }

        private void CheckTarget()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.red, rayLength);
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, InetactableLayer))
            {
                target = hit.transform.GetComponent<IInteractable>();
                if (target.CanUse())
                    imageViewer.Activate(true);
                else
                    imageViewer.Activate(false);
            }
            else
            {
                target = null;
                imageViewer.Activate(false);
            }
        }
    }
}