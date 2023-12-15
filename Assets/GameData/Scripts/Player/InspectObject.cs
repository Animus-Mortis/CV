using Game.Interactable;
using Game.UI;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class InspectObject : MonoBehaviour
    {
        [SerializeField] private Transform pointInspect;
        [SerializeField] private PlayerRotater playerRotater;
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private float speed;
        [SerializeField] private float speedRotate;
        [SerializeField] private SettingData settingData;

        private Vector3 targetPosition;
        private Quaternion targetRotation;
        private Transform newTarget;
        private Clipboard clipboard;
        private InteractableImageViewer ImageViewer;

        private void Update()
        {
            if (newTarget != null
                && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ZoomOut());
            }
        }

        public void SetInteractableImage(InteractableImageViewer interactableImageViewer)
        {
            ImageViewer = interactableImageViewer;
        }

        public void Inspect(Transform target)
        {
            PlayerStatic(false);

            if (target.GetComponent<Clipboard>())
            {
                clipboard = target.GetComponent<Clipboard>();
                clipboard.canUse = false;
            }

            newTarget = target;
            targetPosition = target.position;
            targetRotation = target.rotation;
            target.parent = pointInspect;

            StartCoroutine(ZoomIn());
        }

        private IEnumerator ZoomIn()
        {
            while (Vector3.Distance(newTarget.position, pointInspect.position) > 0.1f
                || newTarget.rotation != pointInspect.rotation)
            {
                newTarget.position = Vector3.Lerp(newTarget.position, pointInspect.position, speed * settingData.speedClipboardMultiplier);
                newTarget.rotation = Quaternion.RotateTowards(newTarget.rotation, pointInspect.rotation, speedRotate * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }

            ImageViewer.ActivePutImage(true);
        }
        private IEnumerator ZoomOut()
        {
            ImageViewer.ActivePutImage(false);
            newTarget.parent = null;

            while (Vector3.Distance(newTarget.position, targetPosition) > 0.1f
                || newTarget.rotation != targetRotation)
            {
                newTarget.position = Vector3.Lerp(newTarget.position, targetPosition, speed * settingData.speedClipboardMultiplier);
                newTarget.rotation = Quaternion.RotateTowards(newTarget.rotation, targetRotation, speedRotate * Time.deltaTime);

                yield return new WaitForFixedUpdate();
            }

            newTarget.position = targetPosition;
            newTarget.rotation = targetRotation;

            if (clipboard != null)
            {
                clipboard.canUse = true;
                clipboard = null;
            }

            newTarget = null;
            PlayerStatic(true);
        }

        private void PlayerStatic(bool active)
        {
            playerMover.CanMove = active;
        }
    }
}
