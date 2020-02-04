using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    bool activated = false;
    public Canvas menuContext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menuContext.enabled = activated;
    }

    public void showMenu(){
        activated = !activated;
    }

    public void restartScene(){
        SceneManager.LoadScene("Laberinto");
    }

    public void exitScene(){
        Application.Quit();
    }
}
