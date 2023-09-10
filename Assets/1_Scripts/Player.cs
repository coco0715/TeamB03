using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        this.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.img);
    }
}
