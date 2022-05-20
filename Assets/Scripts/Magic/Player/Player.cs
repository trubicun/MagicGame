using UnityEngine;
using Zenject;

namespace Magic.Player
{
    public class Player : MonoBehaviour, IPlayer
    {
        public class Factory : PlaceholderFactory<Object, IPlayer>
        {
        }

        public class PlayerFactory : IFactory<Object,IPlayer>
        {
            DiContainer container;

            public PlayerFactory(DiContainer container)
            {
                this.container = container;
            }

            public IPlayer Create(Object prefab)
            {
                return container.InstantiatePrefabForComponent<Player>(prefab);
            }
        }
    }
}