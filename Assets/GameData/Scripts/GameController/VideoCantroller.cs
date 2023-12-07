using Game.Interactable;
using UnityEngine;

namespace Game.GameController
{
    public class VideoCantroller : MonoBehaviour
    {
        private Video[] videos;

        private void Awake()
        {
            videos = GetComponentsInChildren<Video>();

            for (int i = 0; i < videos.Length; i++)
            {
                videos[i].playedAction += StopVideos;
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < videos.Length; i++)
            {
                videos[i].playedAction -= StopVideos;
            }
        }

        private void StopVideos(Video playVideo)
        {
            for (int i = 0; i < videos.Length; i++)
            {
                if (playVideo == videos[i])
                    continue;

                videos[i].StopVideo();
            }
        }
    }
}