using UnityEngine;

namespace Game.UI
{
    public class InteractableImageViewer : MonoBehaviour
    {
        [SerializeField] private GameObject interactableImage;

        private void Awake()
        {
            Activate(false);
        }

        public void Activate(bool active)
        {
            interactableImage.SetActive(active);
        }
    }
}