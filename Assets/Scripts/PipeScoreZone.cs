using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScoreZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
