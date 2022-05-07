using UnityEngine;
using Zenject;

namespace Magic.Player
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] Transform playerOrientation;
        [SerializeField] Rigidbody playerRigidBody;

        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(playerOrientation).WhenInjectedInto<PlayerMovement>();
            Container.BindInterfacesTo<PlayerMovement>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementHandler>().AsSingle();
            Container.Bind<Rigidbody>().FromInstance(playerRigidBody).AsSingle();
        }
    }
}