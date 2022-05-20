using Magic.Player;
using UnityEngine;
using Zenject;

namespace Magic.Model
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] Transform playerSpawn;
        [SerializeField] Object playerPrefab;
        
        [Inject] IFactory<Object, IPlayer> playerFactory;

        void Start()
        {
            var player = playerFactory.Create(playerPrefab);
            
            Debug.Log("Player Created! " + player);
        }
    }
}