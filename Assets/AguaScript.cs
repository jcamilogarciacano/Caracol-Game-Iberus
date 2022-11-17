using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AguaScript : MonoBehaviour
{

    private float speed = 1.0f;
    private SoundManager sM;
    private GameObject target;
    private int i;
    private bool tutoFinished;
    public Collider2D trigger;
    private void Awake()
    {
        //transform.position = new Vector3(-9.2f, 0, 0);
        target = GameObject.FindGameObjectWithTag("Player");


    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTuto(30f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        //if (tutoFinished==true)
        //   {
        if (i > 200)
        {
            transform.position += new Vector3(0, 0.1f, 0);
            i = 0;
        }
        i++;
        //  }
    }
    private IEnumerator WaitForTuto(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        tutoFinished = true;
        //	timer = true;

    }
}
