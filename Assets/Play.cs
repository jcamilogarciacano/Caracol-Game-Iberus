using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Play : MonoBehaviour
{
    public string sName;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        bool r = CrossPlatformInputManager.GetButton("Fire1");
        if (r)
        {
            SceneManager.LoadScene(sName, LoadSceneMode.Single);
        }

    }
}
