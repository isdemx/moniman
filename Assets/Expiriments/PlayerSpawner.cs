using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;


    void Start()
    {
        NetworkObject p = Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
       // p.GetComponent<PlayerMovement>().playerName =
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}