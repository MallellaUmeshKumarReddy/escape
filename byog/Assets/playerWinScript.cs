using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerWinScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject wintext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            wintext.SetActive(true);
            StartCoroutine(waitTime());
            
        }
    }
    
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
    }
}
