using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public void CallOnMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

}
