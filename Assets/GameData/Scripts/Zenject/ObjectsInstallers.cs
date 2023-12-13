using Game.Player;
using Game.UI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Zenject
{
    public class ObjectsInstallers : MonoInstaller
    {
        [SerializeField] private Menu menu;
        [SerializeField] private InteractableImageViewer interactableImageViewer;

        public override void InstallBindings()
        {
            Container.Bind<Menu>().FromInstance(menu).AsSingle().NonLazy();
            Container.QueueForInject(menu);

            Container.Bind<InteractableImageViewer>().FromInstance(interactableImageViewer).AsSingle();
        }
    }
}