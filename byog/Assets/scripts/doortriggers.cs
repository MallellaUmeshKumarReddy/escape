using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortriggers : MonoBehaviour
{
    public GameObject exittext;
    bool exitcard;
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
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exittext.SetActive(true);
            StartCoroutine(texttime());
            exittext.SetActive(false);
        }
       
    }


    IEnumerator texttime()
    {
        yield return new WaitForSeconds(6);
    }
}
