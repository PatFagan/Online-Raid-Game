using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : Photon.MonoBehaviour
{
    Image healthBar;
    void Start()
    {
        healthBar = gameObject.GetComponent<Image>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        stream.SendNext(healthBar.fillAmount);
    }
}