using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private string _scene;
    private GameObject caracol;

    private GameObject soundM;
    private SoundManager sM;
    private CaracolMovement cM;
    // Start is called before the first frame update
    void Start()
    {
        _scene = SceneManager.GetActiveScene().name;
        caracol = GameObject.Find("Caracol");
        soundM = GameObject.Find("SoundManager");
        sM = soundM.GetComponent<SoundManager>();
        cM = caracol.GetComponent<CaracolMovement>();
        print(_scene + "holi");
    }

    // Update is called once per frame
    void Update()
    {
        if (_scene == "1")
        {
            cM.saltar = true;
            cM.rodar = true;
            cM.escalar = true;
            cM.cubrirse = false;
            sM.playWaterEfx(sM.waterEfx.clip);
        }
        if (_scene == "2")
        {
            cM.saltar = true;
            cM.rodar = false;
            cM.escalar = true;
            cM.cubrirse = false;
            sM.playBirdEfx(sM.birdEfx.clip);
        }
        if (_scene == "3")
        {
            cM.saltar = true;
            cM.rodar = false;
            cM.escalar = false;
            cM.cubrirse = true;
        }
        if (_scene == "4")
        {
            cM.saltar = false;
            cM.rodar = true;    
            cM.escalar = false;
            cM.cubrirse = false;
             cM.toNivel = true;
            sM.playBirdEfx(sM.birdEfx.clip);
        }
        if (_scene == "5")
        {
            cM.saltar = false;
            cM.rodar = false;
            cM.escalar = false;
            cM.cubrirse = false;
        }
    }
}
