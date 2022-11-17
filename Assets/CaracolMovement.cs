using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class CaracolMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Anim;
    private SpriteRenderer mySriteRenderer;
    private float m_MaxSpeed = 3f;
    private Transform currPos;
    public float m_JumpForce = 400f;
    private EscalarController eC;
    public bool toNivel;
    public bool onFloor;
    public bool onFloor2;
    public bool cubrirse;
    public bool escalar;
    public bool rodar;
    public bool saltar;

    // Start is called before the first frame update
    private void Awake()
    {
        toNivel =false;
        m_Anim = GetComponent<Animator>();
        mySriteRenderer = GetComponent<SpriteRenderer>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        eC = GameObject.Find("/Caracol/Son").GetComponent<EscalarController>();
    }

    // Update is called once per frame	
    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Vertical");
        float j = CrossPlatformInputManager.GetAxis("Horizontal");
        bool a = CrossPlatformInputManager.GetButton("Jump");
        bool r = CrossPlatformInputManager.GetButton("Fire1");
        bool c = CrossPlatformInputManager.GetButton("Fire2");

        if (saltar == true)
        {
            print(a);
            if (a == true && onFloor == true)
            {
                if (m_Anim.runtimeAnimatorController != null)
                {
                    m_Anim.SetTrigger("Saltando");
                }
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
            if (a == true && onFloor2 == true)
            {
                m_Rigidbody2D.AddForce(new Vector2(0f, -m_JumpForce));
                Physics2D.gravity = new Vector2(0, -9.8f);
                transform.localScale = new Vector3(-1F, 1, 0);
                onFloor2 = false;

            }
        }

        if (escalar == true)
        {
            if (eC.escalando == true)
            {
                MoveEscalando(h, j);
            }
            else
            {
                m_Anim.SetBool("Climbing", false);
            }
        }

        if (c == true && (onFloor == true || onFloor2 == true))
        {
            if (cubrirse == true)
            {
            m_Anim.SetBool("Cubierto", true);
                Hide();
            }
        }
        else
        {
            Move(h, j, r);
        }

    }


    public void Move(float move, float move2, bool r)
    {
        if (m_Anim.runtimeAnimatorController != null)
        {
            m_Anim.SetFloat("Velocidad", Mathf.Abs(move2));
            m_Anim.SetBool("Rodando", false);
             m_Anim.SetBool("Cubierto", false);
        }
        m_Rigidbody2D.velocity = new Vector2(move2 * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        Physics2D.IgnoreLayerCollision(8, 0, false);
        if (move2 < 0)
        {
            if (onFloor2)
            {
                transform.localScale = new Vector3(-1, -1F, 0);
            }
            //mySriteRenderer.flipX = false;
            if (onFloor)
            {
                transform.localScale = new Vector3(-1F, 1, 0);
            }


            if (rodar == true)
                Rodar(r, -1);
        }
        else if (move2 > 0)
        {
            if (onFloor2)
            {
                transform.localScale = new Vector3(1F, -1F, 0);
            }
            //mySriteRenderer.flipX = false;
            if (onFloor)
            {
                transform.localScale = new Vector3(1F, 1, 0);
            }
            if (rodar == true)
                Rodar(r, 1);


            //	mySriteRenderer.flipX = true;
        }
        currPos = this.gameObject.transform;
        if (move2 == 0)
        {
            this.gameObject.transform.position = currPos.position;
        }
        // print(onFloor);
    }
    public void Hide()
    {
        m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed * 0, m_Rigidbody2D.velocity.y);
        Physics2D.IgnoreLayerCollision(8, 0, true);
    }
    public void Rodar(bool r, int m)
    {
        if (r == true && onFloor == true)
        {
            if (m_Anim.runtimeAnimatorController != null)
            {
                m_Anim.SetBool("Rodando", true);
            }
            m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed * 9f * m, m_Rigidbody2D.velocity.y);
    }
    else if (r == true && toNivel == true)
        {
            if (m_Anim.runtimeAnimatorController != null)
            {
                m_Anim.SetBool("Rodando", true);
            }
            m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed * 9f * m, m_Rigidbody2D.velocity.y);
          //  m_Rigidbody2D.AddForce(new Vector2(m_JumpForce, m_JumpForce/3));
    }
    }
    public void MoveEscalando(float move, float move2)
    {
        if (m_Anim.runtimeAnimatorController != null)
        {
            m_Anim.SetBool("Climbing", true);
        }
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, move * m_MaxSpeed);
    }
    void OnCollisionExit2D(Collision2D col)
    {
        onFloor = false;
        onFloor2 = false;

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            onFloor = true;
        }
        if (col.gameObject.tag == "Escalable")
        {
            onFloor = true;
        }
        if (col.gameObject.tag == "Escalable2")
        {
            onFloor2 = true;
            Physics2D.gravity = new Vector2(0, 9.8f);

        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //	print ("esquivando");
        if (col.gameObject.tag == "Suelo")
        {
            onFloor = true;
        }
        if (col.gameObject.tag == "Escalable")
        {
            onFloor = true;
        }
        if (col.gameObject.tag == "Escalable2")
        {
            onFloor2 = true;
            transform.localScale = new Vector3(1, -1F, 0);
            Physics2D.gravity = new Vector2(0, 9.8f);

        }

    }
    private IEnumerator WaitForRecoil(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        onFloor = true;
        //	timer = true;

    }

}
