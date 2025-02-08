using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Control quit system
    // Audio
    // Raycasting, click and dragging

    public GameObject PauseUI, DialogueUI;
    public static GameManager Instance; // singleton

    bool isPaused;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        isPaused = false;
        PauseUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Photo" && !isPaused && hit.collider.gameObject.GetComponent<Photo>() != null)
                {
                    Photo hitPhoto = hit.collider.gameObject.GetComponent<Photo>();

                }
                //if (hitPhoto.GetIsCompleteBool())
                //{
                //    if (Input.GetMouseButtonUp(0))
                //    {
                //        Debug.Log("clicked on the photo again");
                //        //SceneManager.LoadScene(hitPhoto.GetNextScene());
                //    }

                //}
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            isPaused = true;
        }
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // fading to black
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        isPaused = false;
        PauseUI.SetActive(false); 
        // might need to set time scale?
    }

}
