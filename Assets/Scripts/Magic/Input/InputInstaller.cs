using UnityEngine;
using Zenject;

namespace Magic.Input
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        [SerializeField] Settings.InputSettings inputSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().To<PlayerInput>().AsSingle();
            Container.Bind<Settings.InputSettings>().FromInstance(inputSettings).AsSingle();
        }
    }
}
