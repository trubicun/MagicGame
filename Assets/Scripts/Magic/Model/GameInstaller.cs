using Magic.Player;
using Magic.Settings;
using UnityEngine;
using Zenject;

namespace Magic.Model
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] EntitySettings entitySettings;
        [SerializeField] PlayerSpawn playerSpawn;
        
        public override void InstallBindings()
        {
            Container.Bind<EntitySettings>().FromInstance(entitySettings).AsSingle();
            Container.Bind<PlayerSpawn>().FromInstance(playerSpawn).AsSingle();
            
            Container.BindIFactory<Object, IPlayer>().FromFactory<PrefabFactory<Player.Player>>();
        }
    }
}