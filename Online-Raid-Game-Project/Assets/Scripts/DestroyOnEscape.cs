using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEscape : MonoBehaviour
{
    public string escapeTag;

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == escapeTag)
        {
            Destroy(gameObject);
        }
    }
}