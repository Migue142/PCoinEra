using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Jugador : MonoBehaviour
{
    [SerializeField] private float FuerzaM = 0.1f;
    [SerializeField] private int FuersaSalto = 5;
    [SerializeField] private bool enSuelo = false;
    [SerializeField] private int vidas;
    [SerializeField] private int monedas;
    private bool perdiste = false;

    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text texto_vidas;
    [SerializeField] private TMP_Text texto_monedas;
    [SerializeField] private GameObject fondo;

    private Rigidbody2D rb;


    void Start()
    {
        vidas = 3;
        monedas = 0;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(new Vector2(0, FuersaSalto), ForceMode2D.Impulse);
        }
        texto_vidas.text = vidas.ToString();
        texto_monedas.text = monedas.ToString();


    }

    void FixedUpdate()
    {
        if (!perdiste)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = transform.position + new Vector3(-FuerzaM, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                animator.SetBool("isRun", true);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = transform.position + new Vector3(FuerzaM, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                animator.SetBool("isRun", true);
            }

            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("isRun", false);
            }

            if (rb.linearVelocity.y > 0)
            {
                animator.SetInteger("isJump", 1);
            }
            else if (rb.linearVelocity.y < 0)
            {
                animator.SetInteger("isJump", -1);
            }
            else
            {
                animator.SetInteger("isJump", 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enSuelo = true;
        print("Colisiono con algo");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
        print("No està colisionando");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("vida")) {
            Destroy(collision.gameObject);
            vidas++;
        }

        if (collision.CompareTag("moneda"))
        {
            Destroy(collision.gameObject);
            monedas++;
        }

        if (collision.CompareTag("trampa"))
        {
            vidas--;

            if (vidas > 0)
            {
                transform.position = new Vector3(-0.54f, -3.528f, 0);
            }

            if (vidas == 0){
                perdiste = true;
                fondo.SetActive(true);
            }
        }

        if (collision.CompareTag("meta"))
        {
            Debug.Log("Completaste el nivel!");
        }
    }
}
