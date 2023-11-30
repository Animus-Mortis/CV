using UnityEngine;
namespace Game.Player
{
    public class MouseInput
    {
        public static Vector2 MouseRotate(float mouseSpeed, Vector2 turnXLimiter)
        {
            Vector2 rotateVector;
            rotateVector.x = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;
            rotateVector.y = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
            rotateVector.x = Mathf.Clamp(rotateVector.x, turnXLimiter.x, turnXLimiter.y);

            return rotateVector;
        }
    }
}