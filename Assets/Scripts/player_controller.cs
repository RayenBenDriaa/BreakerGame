using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    public Animator anim;
    public Animator Dooranim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public GameObject Healthpotion;
    public GameObject Manapotion;
    public bool grounded,tr;
    public GameManger healthbar;
    int maxHealth=100;
    int currentHealth;
    GameObject obj;
    private Text tooltiptext;
    public GameObject Explosion;


    /*
    void Awake()
    {
#if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
#endif
    }*/
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        currentHealth = maxHealth;
        healthbar.SetMaxhealth(maxHealth);

    }
     private void Update()
    {
       
        if (currentHealth <= 0)
        {
            obj = GameObject.Find("walking");
            Debug.Log("i killed the monster");
            Destroy(obj);
            StartCoroutine(waitforDestroy());
        }

    }
    


    // Update is called once per frame
    private void FixedUpdate()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        
        Grounded();
        Jump();
        if (Input.GetButton("Sprint") && verticalAxis != 0)
        { 
            run();
        }
        else {
            Move(); 
        }
            
        Boxe();
        Spell();

    }
    // jumping when clicking space
    private void Jump()
    {
        bool s = this.anim.GetBool("run");
        if ((Input.GetButtonDown("Jump") && this.grounded && !s))
        {
            //loading jump animation
            this.anim.SetBool("jump", false);

            this.rb.AddForce(Vector3.up * 4f, ForceMode.Impulse);

        }

    }
    void givedamage(int dmg)
    {
        currentHealth -= dmg;
        healthbar.Sethealth(currentHealth);
    }

    IEnumerator waitforAnimation()
    {
        yield return new WaitForSeconds(1.7f);
        this.anim.SetBool("boxe", true);
    }
    //Attack function
    private void Boxe()
    {
        if (Input.GetButtonDown("Fire1") && this.grounded)
        {
            this.anim.SetBool("boxe", false);
            StartCoroutine(waitforAnimation());
            givedamage(10);



        }

    }
    IEnumerator waitforAnimation3()
    {
        yield return new WaitForSeconds(1.7f);
        this.anim.SetBool("spell", true);
        Explosion.SetActive(false);

    }
    IEnumerator waitforDestroy()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("level2Scene");

    }
    //spell function
    private void Spell()
    {
        if (Input.GetButtonDown("spell") && this.grounded)
        {
            Debug.Log("hola");
            this.anim.SetBool("spell", false);
            Explosion.SetActive(true);
            StartCoroutine(waitforAnimation3());
            givedamage(30);

        }

    }


    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;

        }
        else
        {
            this.grounded = false;

        }
        this.anim.SetBool("jump", this.grounded);
    }
    //movment function
    private void Move()
    {
        this.anim.SetBool("run", false);
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.position += (movement * 0.7f) * Time.deltaTime;
        this.anim.SetFloat("vertical", verticalAxis == 0 ? Mathf.Abs(horizontalAxis) : verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);

    }
    //when i press left shift he run
    private void run()
    {




        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        this.transform.Translate(Vector3.forward*3*Time.fixedDeltaTime);
        this.anim.SetBool("run",true);
        


    }
    //this function call the door animation to open
    public void openDoor()
    {
        bool b = this.Dooranim.GetBool("Dooropen");
      
            if (b)
            {
                this.Dooranim.SetBool("Dooropen", false);
                
            }
            else
            {

                this.Dooranim.SetBool("Dooropen", true);
            }
     }




    //this function for using the laptop
    public void useLaptop()
    {
        SceneManager.LoadScene("cine2");


    }
    
    /// <summary>
    /// this function is used when the player picks up the object
    /// </summary>
    public void pickBat()
    {
        obj = GameObject.Find("Bottle_Health");
        Destroy(obj);
        Healthpotion.SetActive(true);

    }
    public void pickSpell()
    {
        obj = GameObject.Find("Bottle_Mana");
        Destroy(obj);
        Manapotion.SetActive(true);


    }


    private void showToolTip(string textvar)
    {
        

    }

}
