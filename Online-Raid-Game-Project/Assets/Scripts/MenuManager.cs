using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";

    [SerializeField] private GameObject startButton;

    public string nextScene;

    private void Awake() // set up photon settings on start
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void OnConnectedToMaster() // joined lobby
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
        startButton.SetActive(true);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3; // maybe add a thing where if the player amount is exceeded, then universallobby gets a number tacked on
        PhotonNetwork.JoinOrCreateRoom("universallobby", roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(nextScene);
    }
}