using Zenject;

namespace Magic.Model
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            //Container.BindInterfacesTo<GameManager>().AsSingle();
        }
    }
}