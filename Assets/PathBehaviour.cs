using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PathBehaviour : MonoBehaviour
{
    SpriteRenderer rend;
    public Color newColor;
    public Color oldColor;
    public string mapName;
    bool pathAvailable = false; //check if collision happened

    SceneChanger blackFadeScript;
    public GameObject blackFade;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = oldColor;
        blackFadeScript = blackFade.GetComponent<SceneChanger>();
    }


    private void Update()
    {
        // Check if W is pressed while the path is colliding with player
        if (pathAvailable && Input.GetKeyDown(KeyCode.W))
        {
            SelectPath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("nonCat"))
        {
            ShowPath();
            pathAvailable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("nonCat"))
        {
            HidePath();
            pathAvailable = false; 
        }
    }

    void ShowPath()
    {
        rend.color = newColor;
    }

    void HidePath()
    {
        rend.color = oldColor;
    }




    void SelectPath()
    {
        blackFadeScript.sceneName = mapName;
        blackFadeScript.SceneChange();
    }

}
