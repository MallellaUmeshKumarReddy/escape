using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] Animator sceneAnim;
    [SerializeField] GameObject animImage;    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
        animImage.SetActive(false);
        sceneAnim.SetTrigger("fadein");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void start()
    {
        SceneManager.LoadScene(1);
        sceneAnim.SetTrigger("fadein");
    }


}
