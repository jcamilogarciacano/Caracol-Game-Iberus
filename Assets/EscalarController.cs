using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalarController : MonoBehaviour
{
	public bool escalando;
    // Start is called before the first frame update
    void Start()
    {
        escalando = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col){
	//	print ("esquivando");
		if (col.gameObject.tag == "Escalable") {
			escalando = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
			escalando = false;
	}
}
