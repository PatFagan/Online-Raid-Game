using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInstanceManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject sceneCamera;
    public TMP_Text pingText;
    public GameObject playerSpawn;

    public GameObject disconnectUI;
    private bool isDisconnectUIoff = false;

    public GameObject playerFeed;
    public GameObject feedGrid;

    void Start()
    {
        SpawnPlayer();
    }

    private void Update()
    {
        // sets ping text
        //pingText.text = "Ping: " + PhotonNetwork.GetPing();

        CheckInput();
    }

    private void CheckInput()
    {
        if (isDisconnectUIoff && Input.GetButtonDown("Escape")) // disable escape menu
        {
            disconnectUI.SetActive(false);
            isDisconnectUIoff = false;
        } 
        else if (!isDisconnectUIoff && Input.GetButtonDown("Escape")) // enable escape menu
        {
            disconnectUI.SetActive(true);
            isDisconnectUIoff = true;
        }
    }

    public void LeaveRoom() // disconnect
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }

    // spawns player and disables game canvas
    public void SpawnPlayer()
    {
        playerPrefab.SetActive(true);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(playerSpawn.transform.position.x, playerSpawn.transform.position.y), Quaternion.identity, 0);
        sceneCamera.SetActive(true);
    }

    private void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject feedLine = PhotonNetwork.Instantiate(playerFeed.name, new Vector2(0, 0), Quaternion.identity, 0); // create text line
        feedLine.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        feedLine.GetComponent<TMP_Text>().text = player.NickName + " joined the game"; // set text
        feedLine.GetComponent<TMP_Text>().color = Color.green; // set text color
    }

    private void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject feedLine = PhotonNetwork.Instantiate(playerFeed.name, new Vector2(0, 0), Quaternion.identity, 0); // create text line
        feedLine.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        feedLine.GetComponent<TMP_Text>().text = player.NickName + " left the game";
        feedLine.GetComponent<TMP_Text>().color = Color.red;
    }

    public void ReviveFeed(string reviver, string revivee)
    {
        GameObject feedLine = PhotonNetwork.Instantiate(playerFeed.name, new Vector2(0, 0), Quaternion.identity, 0); // create text line
        feedLine.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        feedLine.GetComponent<TMP_Text>().text = reviver + " revived " + revivee;
        feedLine.GetComponent<TMP_Text>().color = Color.yellow;
    }

    public void DeathFeed(string deadPlayer)
    {
        GameObject feedLine = PhotonNetwork.Instantiate(playerFeed.name, new Vector2(0, 0), Quaternion.identity, 0); // create text line
        feedLine.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        feedLine.GetComponent<TMP_Text>().text = deadPlayer + " has died";
        feedLine.GetComponent<TMP_Text>().color = Color.red;
    }
}