using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class toScene2 : MonoBehaviour
{

    public string sName;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (i > 500)
        {
            SceneManager.LoadScene(sName, LoadSceneMode.Single);
        }
        i++;

    }
}
