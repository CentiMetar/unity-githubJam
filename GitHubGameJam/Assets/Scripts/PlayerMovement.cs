using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform player;
    public float sidewaysForce = 500f;
    public float dashForce=10f;
    private bool OnGround = true;
    public float verticalForce=100f;
    private int br=0;
    private float startingTime=0f;
    private bool dashable=true;
    public SetDash setDash;
    
    void FixedUpdate()
    {
        //Pomeranje

        //E brt mozes da koristis rb.Velocity za movement bolje ti je jer ti stavlja taj speed koji stavis ovo ti je incrementalno
        //Ili mozes samo mathf.clamp da koristis da clampujes max speed da nebi klizalo
        //A za das koristi rb.addforce sa impulse modom ili koristi dve animacije fiksne za dash ovako ti je vise blink kao tp
        //Mada nzm dal to hoces ali mi nema logike

        //P.S. Isto uglavnom kad imenujes gledaj da su bool tipovi isGrounded, nemoras da menjas ali tako se uglavnom radi u industriji
        //To ti se zovu state-ovi, isGrounded, isDead, isPoisoned itd.
        //Dobro si odradio ui, ja bih sve u jednom skriptu ali ovako je preglednije bolje je  
        if(Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(sidewaysForce * Time.deltaTime,0)/*,ForceMode2D.Impulse*/);  
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-sidewaysForce * Time.deltaTime,0)/*,ForceMode2D.Impulse*/);
        }
        //Dash
        if (Input.GetKey("e") && dashable==true)
        {
            GetComponent<Animator>().Play("Dash");
            player.position=new Vector2(player.position.x+dashForce,player.position.y);
            dashable=false;
            br++;
            startingTime=Time.timeSinceLevelLoad;
            Invoke("yesDashable",3);
        }

        if (Input.GetKey("q") && dashable==true)
        {
            GetComponent<Animator>().Play("Dash");
            
            player.position=new Vector2(player.position.x-dashForce,player.position.y);
            dashable=false;
            br++;
            startingTime=Time.timeSinceLevelLoad;
            Invoke("yesDashable",3);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag=="Ground")
        OnGround=true;
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && OnGround==true)
        {
            rb.AddForce(new Vector2(0,verticalForce),ForceMode2D.Impulse);
            OnGround=false;
        }
        if(br>0)
        {
            setDash.FillDash(Time.timeSinceLevelLoad-startingTime);
        }
        else
        {
            setDash.FillDash(3f);
        }
    }
    void yesDashable()
    {
        dashable=true;
    }
}
