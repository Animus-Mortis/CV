using UnityEngine;

namespace Game.UI
{
    public class LoadingImage : MonoBehaviour
    {
        [SerializeField] private GameObject Image;

        public void ActiveImage(bool active)
        {
            Image.SetActive(active);
        }
    }
}
