using UnityEngine;

namespace Game.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private MouseInput mouseInput;

        private CharacterController controller;
        private float speed;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (Input.GetButton("Run"))
                speed = runSpeed;
            else
                speed = walkSpeed;

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
        }
    }
}