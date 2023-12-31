using Game.GameController;
using Game.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game.Player
{
    public class SpawnPlayer : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private string prefName;
        [SerializeField] private LoadingImage loadingImage;
        [SerializeField] private SettingController settingController;

        private GameObject player;
        [Inject] private Menu menu;
        [Inject] private InteractableImageViewer imageViewer;

        private void Awake()
        {
            InstantiateGameobject(prefName);
        }

        private void OnDisable()
        {
            ReleaseGameobject();
        }

        public void InstantiateGameobject(string key)
        {
            Addressables.InstantiateAsync(key).Completed += OnLoadDone;
        }

        private void OnLoadDone(AsyncOperationHandle<GameObject> obj)
        {
            player = obj.Result;
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;

            player.GetComponent<PlayerRotater>().SetMenu(menu);
            player.GetComponent<PlayerRotater>().SetSettingController(settingController);
            player.GetComponent<PlayerMover>().SetMenu(menu);
            player.GetComponent<InspectObject>().SetInteractableImage(imageViewer);
            player.GetComponent<InspectObject>().SetSettingController(settingController);
            player.GetComponentInChildren<IneractableCheck>().SetInteractableImage(imageViewer);

            loadingImage.ActiveImage(false);
        }

        public GameObject GetPlayer()
        {
            return player;
        }

        public void ReleaseGameobject()
        {
            Addressables.Release(player);
        }
    }
}