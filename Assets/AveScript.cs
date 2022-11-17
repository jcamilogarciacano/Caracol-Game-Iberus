using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AveScript : MonoBehaviour
{
    private float speed = 1.0f;
    private GameObject target;
    private int i = 0;
    public int  multiplier =1;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {

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
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step* multiplier);
        if (i > 200)
        {
            transform.position += new Vector3(0, 0.1f, 0);
            i = 0;
        }
        i++;
    }
}
