using UnityEngine;

namespace Game.UI
{
    public class InteractableImageViewer : MonoBehaviour
    {
        [SerializeField] private GameObject interactableImage;
        [SerializeField] private GameObject putObjectImage;

        private void Awake()
        {
            ActivateInteractableImage(false);
            ActivePutImage(false);
        }

        public void ActivateInteractableImage(bool active)
        {
            interactableImage.SetActive(active);
        }

        public void ActivePutImage(bool active)
        {
            putObjectImage.SetActive(active);
        }
    }
}