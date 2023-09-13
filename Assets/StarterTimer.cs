using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterTimer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Coin")
        {
            Managers.GameManager.IsStartedTimer = true;
        }
    }
}
