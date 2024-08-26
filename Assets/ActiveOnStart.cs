using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveOnStart : MonoBehaviour
{
    public GameObject[] gameObjectsList;
   



    void Awake()
    {
        ActivateAllGameObjects();
    }




    void ActivateAllGameObjects()
    {
        // Loop through each GameObject in the list
        foreach (GameObject obj in gameObjectsList)
        {
            // Check if the GameObject is not null to avoid errors
            if (obj != null)
            {
                // Set the GameObject to active
                obj.SetActive(true);
            }
        }
    }

  
}
