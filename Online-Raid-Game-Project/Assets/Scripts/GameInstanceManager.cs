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
        Instantiate(playerPrefab, new Vector2(playerSpawn.transform.position.x, playerSpawn.transform.position.y), Quaternion.identity);
        sceneCamera.SetActive(true);
    }
}