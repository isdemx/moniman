using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class FusionConnectionScript : Fusion.Behaviour, INetworkRunnerCallbacks
{
    [Header("Game Arguments")]

    [SerializeField]
    private GameMode gameMode;
    [SerializeField]
    private string roomName;

    [SerializeField]
    NetworkRunner runner;
    private INetworkSceneManager sceneManager;

    

    public InputField playerName;
    public string pName = "Василий";

    [SerializeField] InputField roomNameInputField;
    public GameObject PlayerPrefab;

    public FusionBootstrap bs;

    private void Awake()
    {
        if (runner == null)
        {
            if (transform.gameObject.GetComponent<NetworkRunner>())
            {
                runner = transform.gameObject.GetComponent<NetworkRunner>();
            }
            else
            {
                runner = gameObject.AddComponent<NetworkRunner>();
            }

        }
        
    }

    // Utility method to Join the ClientServer Lobby
    public async Task JoinLobby(NetworkRunner runner)
    {

        var result = await runner.JoinSessionLobby(SessionLobby.ClientServer);

        if (result.Ok)
        {
            // all good
        }
        else
        {
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
        }
    }


    // Создание игры простое
    public async void ConnectGame()
    {
        if (playerName != null)
        {
            await Connect();
        }
        
    }
    public async Task Connect()
    {
        if (sceneManager == null) sceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>();

        var args = new StartGameArgs()
        {
            SceneManager = sceneManager,
            SessionName = roomNameInputField.text,
            GameMode = GameMode.Shared,
            CustomLobbyName = roomNameInputField.text,
            PlayerCount = 5,
            IsOpen = true,
            IsVisible = true,

        };

        await runner.JoinSessionLobby(SessionLobby.ClientServer, runner.SessionInfo.Name);
        
        await runner.StartGame(args);
        
        Debug.Log("ВЫ СОЗДАЛИ КОМНАТУ С ИМЕНЕМ: " + runner.SessionInfo.Name);
        
        await runner.LoadScene("driverReady", default, default);
        
    }

    public async void JoinRoom()
    {
        if(sceneManager == null) sceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>();

        var args = new StartGameArgs()
        {
            GameMode = GameMode.Host,
            SessionName = roomNameInputField.text,

            SceneManager = sceneManager,

        };

        
        pName = playerName.text;
        PlayerPrefs.SetString("playerName", pName);

        await runner.StartGame(args);

        await runner.LoadScene("driverReady", default, default);
      
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("on connected to server!");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.LogWarning("on connected Failed!");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        Debug.LogWarning("server disconnect");
    }

    // присоединение игрока
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("Join game: " + player.PlayerId + ": " + playerName.text);

        if (player == runner.LocalPlayer)
        {
            NetworkObject p = runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            p.GetComponent<PlayerNickName>().PlayerName = pName;
            p.GetComponent<PlayerNickName>().OnNameChanged();
            
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("Left game: " + player.PlayerId);
    }

    // блять не работает говно блять
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Debug.Log(sessionList.Count);

        //Debug.Log("СПИСОК КОМНАТ: " + sessionList[0].Name + ", Players: " + sessionList[0].PlayerCount + "/" + sessionList[0].MaxPlayers);
        
        

    }

    public void StartSinglePlayerGame()
    {
        SceneManager.LoadScene("driver");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    // not used
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
       
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        
    }



    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
      
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }


    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
      
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }

    public void Update()
    {
        
    }

    public void Rename()
    {
        pName = playerName.text;
    }
}
