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
        [SerializeField] private string nameFileClip;


        public void Action()
        {
            PlayVideo();
        }

        public bool CanUse()
        {
            return !videoPlayer.isPlaying;
        }

        private void PlayVideo()
        {
            string clipPath = Path.Combine(Application.streamingAssetsPath, nameFileClip);
            videoPlayer.url = clipPath;
            videoPlayer.Play();
        }
    }
}