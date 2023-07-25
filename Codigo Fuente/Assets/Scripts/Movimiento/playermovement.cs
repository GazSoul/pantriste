using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public AudioClip hurt, heal, dash;
    public AudioClip[] jump;
    AudioClip lastClip;
    public AudioSource audioS;

[SerializeField] private DialogueUI dialogueUI;
	public DialogueUI DialogueUI => dialogueUI;
	public Interactable Interactable2 { get; set;}


    public bool damaged = false;
    public CharacterController2D controller;
    public float moveSpeed = 5f;
    float xInput, yInput;
    Rigidbody2D rb;
    SpriteRenderer sp;
    public float jumpSpeed = 8f;
    public Transform groundCheck;
    public LayerMask groundLayer; 
    bool isGrounded;
    float horizontalMove = 0f;
    public int jumpqty = 0;
    public int jumpcalc;
    bool lleft;
    bool lright;
    public float dashcdbase = 2;
    float dashcd;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite, oldSprite, dwnSprite;
  //  [SerializeField] private GameObject gauge;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpcalc = jumpqty;
        dashcd = 0f;
        lright = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){


    if (Input.GetKeyDown(KeyCode.E))
		{
			if(Interactable2 != null)
			{
				Interactable2.Interact(this);
			}
		}


        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        if(dashcd <= 0){
            dashcd = 0;
        }else{
            dashcd -= 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcd == 0f){
        audioS.PlayOneShot(dash);
            if(lright){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed*2, 0F), ForceMode2D.Impulse);
            dashcd = dashcdbase;
            }else if (lleft){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed*2, 0F), ForceMode2D.Impulse);
            dashcd = dashcdbase;
            }
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f, groundLayer);
        if (isGrounded)
            {   
                if(Input.GetKey(KeyCode.DownArrow)){
                    ChangeSprite(dwnSprite);
                }else if(Input.GetKey(KeyCode.UpArrow)){
                    ChangeSprite(newSprite);
                }else{
                    ChangeSprite(oldSprite);
                }
                if(Input.GetButtonDown("Jump")){
                Jump();
                }
                jumpcalc = jumpqty;

            }else if(jumpcalc != 0){
                if(Input.GetButtonDown("Jump")){
                Jump();
                }
            }
            if(damaged){
                RecieveDamage();
            }
    }
    
    private void FixedUpdate() {
        controller.Move(horizontalMove* Time.fixedDeltaTime, false, false);
        if(xInput<0){
            lleft = true;
            lright = false;
        }else if(xInput>0){
            lleft = false;
            lright = true;
        }
    }

    void Jump(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        audioS.PlayOneShot(RandomClip());
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        ChangeSprite(newSprite);
        jumpcalc -= 1;
    }

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite; 
    }

    public void RecieveDamage(){
        Vector2 vel = gameObject.GetComponent<Rigidbody2D>().velocity;
        int retroceso = 3*-1;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(vel.x*retroceso,vel.y*retroceso), ForceMode2D.Impulse);
        spriteRenderer.color = Color.red;
        audioS.PlayOneShot(hurt);
        print("Pito");
        Invoke("normal", 1);
        damaged = false;
    }
    void normal(){
        spriteRenderer.color = Color.white;
        print("Pito");
    }
    public void RecieveRecover(){
        spriteRenderer.color = Color.green;
        audioS.PlayOneShot(heal);
        Invoke("normal", 1);
    }
    
    public AudioClip RandomClip(){
    int attempts = 3;
    AudioClip newClip = jump[Random.Range(0, jump.Length)];
    while (newClip == lastClip && attempts > 0) 
    {
      newClip = jump[Random.Range(0, jump.Length)];
      attempts--;
    }
    lastClip = newClip;
    return newClip;
  }
}