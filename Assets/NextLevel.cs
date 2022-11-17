using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{

	public string sName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 void OnTriggerEnter2D(Collider2D col)
    {
        //	print ("esquivando");
        if (col.gameObject.tag == "Player")
        {
    SceneManager.LoadScene(sName, LoadSceneMode.Single);
}
}
}
