using Magic.Settings;
using UnityEngine;
using Zenject;

namespace Magic.Player
{
    public class PlayerSpawn : MonoBehaviour
    {
        IFactory<Object, IPlayer> playerFactory;
        EntitySettings entitySettings;

        [Inject]
        void Init(IFactory<Object, IPlayer> playerFactory, EntitySettings entitySettings)
        {
            this.playerFactory = playerFactory;
            this.entitySettings = entitySettings;
        }
        
        public void SpawnPlayer()
        {
            playerFactory.Create(entitySettings.Player);
        }
    }
}