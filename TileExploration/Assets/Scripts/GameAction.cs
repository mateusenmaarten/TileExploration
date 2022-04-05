using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAction : MonoBehaviour
{
    public Action Action;

    void OnMouseDown()
    {
        Debug.Log("Do Action");
        //Do Action 
    }

    private void OnMouseOver()
    {
        Debug.Log("Showing Tooltip");
        //Show Tooltip
    }

    private void OnMouseExit()
    {
        Debug.Log("Tooltip No longer visible");
        //Destroy Tooltip
    }
}
