using UnityEngine;

namespace Game.Player
{
    public class PlayerRotater : MonoBehaviour
    {
        [SerializeField] private MouseInput mouseInput;
        [SerializeField] private SettingData settings;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform body;
        [SerializeField] private float mouseSpeed;
        [SerializeField] private Vector2 turnXLimiter;

        [HideInInspector] public bool CanRotate;

        private Vector2 mouseRotate;
        private float xRotate;

        private void LateUpdate()
        {
            if (!CanRotate) return;

            mouseRotate = MouseInput.MouseRotate(mouseSpeed* settings.mouseSensitiveMultiplier);

            xRotate += mouseRotate.x;
            xRotate = Mathf.Clamp(xRotate, turnXLimiter.x, turnXLimiter.y);
            cameraTransform.localEulerAngles = Vector3.left * xRotate;

            body.Rotate(Vector3.up * mouseRotate.y);
        }
    }
}