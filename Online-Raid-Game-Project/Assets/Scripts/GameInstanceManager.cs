using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInstanceManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    public TMP_Text pingText;

    public GameObject disconnectUI;
    private bool isDisconnectUIoff = false;

    public GameObject playerFeed;
    public GameObject feedGrid;

    private void Awake()
    {
        // activates game canvas on start
        gameCanvas.SetActive(true);
    }

    private void Update()
    {
        // sets ping text
        pingText.text = "Ping: " + PhotonNetwork.GetPing();

        CheckInput();
    }

    private void CheckInput()
    {
        if (isDisconnectUIoff && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            isDisconnectUIoff = false;
        } 
        else if (!isDisconnectUIoff && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            isDisconnectUIoff = true;
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }

    // spawns player and disables game canvas
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-10f, 10f);

        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        //sceneCamera.SetActive(false);
    }

    private void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(playerFeed, new Vector2(0, 0), Quaternion.identity); // create text line
        obj.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        obj.GetComponent<TMP_Text>().text = player.NickName + " joined the game"; // set text
        obj.GetComponent<TMP_Text>().color = Color.green; // set text color
    }

    private void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(playerFeed, new Vector2(0, 0), Quaternion.identity); // create text line
        obj.transform.SetParent(feedGrid.transform, false); // make text line child of feed grid
        obj.GetComponent<TMP_Text>().text = player.NickName + " left the game";
        obj.GetComponent<TMP_Text>().color = Color.red;
    }
}
