using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject connectPanel;
    [SerializeField] private GameObject usernamePanel;

    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField createGameInput;
    [SerializeField] private TMP_InputField joinGameInput;

    [SerializeField] private GameObject startButton;

    public int USERNAME_LENGTH = 3;

    private void Awake() // set up photon settings on start
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start() // open username panel on start button click
    {
        usernamePanel.SetActive(true);
    }

    private void OnConnectedToMaster() // joined lobby
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput()
    {
        if (usernameInput.text.Length >= USERNAME_LENGTH) // start button clickable if username long enough
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void SetUsername()
    {
        usernamePanel.SetActive(false); // once username is set, close username panel
        PhotonNetwork.playerName = usernameInput.text; // set username input to photon username
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { MaxPlayers = 6 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, roomOptions, TypedLobby.Default);
    }
}
