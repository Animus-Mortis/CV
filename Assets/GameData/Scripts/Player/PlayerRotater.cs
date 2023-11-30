using UnityEngine;
namespace Game.Player
{
    public class PlayerRotater : MonoBehaviour
    {
        [SerializeField] private MouseInput mouseInput;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform body;
        [SerializeField] private float mouseSpeed;
        [SerializeField] private Vector2 turnXLimiter;

        private Vector2 mouseRotate;

        private void LateUpdate()
        {
            mouseRotate = MouseInput.MouseRotate(mouseSpeed, turnXLimiter);
            mouseRotate.x = Mathf.Clamp(mouseRotate.x, turnXLimiter.x, turnXLimiter.y);

            cameraTransform.Rotate(Vector3.left * mouseRotate.x);
            body.Rotate(Vector3.up * mouseRotate.y);
        }
    }
}