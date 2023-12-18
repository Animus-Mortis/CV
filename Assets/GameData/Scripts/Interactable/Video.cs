using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Video;

namespace Game.Interactable
{
    public class Video : MonoBehaviour, IInteractable
    {
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private Material videoMaterial;
        [SerializeField] private string nameFileClip;

        public Action<Video> playedAction;

        private Renderer rendererThis;

        private void Awake()
        {
            rendererThis = GetComponent<Renderer>();
        }

        public void Action()
        {
            PlayVideo();
            playedAction?.Invoke(this);
        }

        public bool CanUse()
        {
            return !videoPlayer.isPlaying;
        }

        public void StopVideo()
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Stop();
        }

        private void PlayVideo()
        {
            rendererThis.material = videoMaterial;
            string clipPath = Path.Combine(Application.streamingAssetsPath, nameFileClip);
            videoPlayer.url = clipPath;
            videoPlayer.Play();
        }
    }
}