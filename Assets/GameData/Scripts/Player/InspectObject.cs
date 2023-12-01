using Game.Interactable;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class InspectObject : MonoBehaviour
    {
        [SerializeField] private Transform pointInspect;
        [SerializeField] private PlayerRotater playerRotater;
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private Vector3 rotate;
        [SerializeField] private float speed;
        [SerializeField] private float speedRotate;

        private Vector3 targetPosition;
        private Quaternion rotateObject;
        private Quaternion targetRotation;
        private Transform newTarget;
        private Transform mainCamera;
        private Clipboard clipboard;

        private void Awake()
        {
            mainCamera = Camera.main.transform;
        }

        private void Update()
        {
            if (newTarget != null
                && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ZoomOut());
            }
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

            Vector3 targetDir = mainCamera.position- newTarget.position + rotate;
            rotateObject = Quaternion.LookRotation(targetDir);

            StartCoroutine(ZoomIn());
        }

        private IEnumerator ZoomIn()
        {
            while (Vector3.Distance(newTarget.position, pointInspect.position) > 0.1f
                || newTarget.rotation != rotateObject)
            {
                newTarget.position = Vector3.Lerp(newTarget.position, pointInspect.position, speed);
                newTarget.rotation = Quaternion.RotateTowards(newTarget.rotation, rotateObject, speedRotate * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }
        private IEnumerator ZoomOut()
        {
            newTarget.parent = null;

            while (Vector3.Distance(newTarget.position, targetPosition) > 0.1f
                || newTarget.rotation != targetRotation)
            {
                newTarget.position = Vector3.Lerp(newTarget.position, targetPosition, speed);
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
            playerMover.enabled = active;
            //playerRotater.enabled = active;
        }
    }
}
