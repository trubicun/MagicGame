using Magic.Player;
using UnityEngine;
using Zenject;

namespace Magic.Model
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        PlayerSpawn playerSpawn;
        
        [Inject]
        void Init(PlayerSpawn playerSpawn)
        {
            this.playerSpawn = playerSpawn;
        }

        void Start()
        {
            playerSpawn.SpawnPlayer();
        }
    }
}