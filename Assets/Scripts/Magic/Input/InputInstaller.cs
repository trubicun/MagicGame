using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Magic.Input
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] Settings.InputSettings inputSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().FromInstance(playerInput).AsSingle();
            Container.Bind<Settings.InputSettings>().FromInstance(inputSettings).AsSingle();
        }
    }
}
