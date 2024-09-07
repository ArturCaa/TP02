using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;  // Vitesse de déplacement vers l'avant/arrière

    [SerializeField]
    private float turnSpeed = 100.0f;

    public float strafeSpeed = 5.0f;  // Vitesse de déplacement latéral (gauche/droite)
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    private void FixedUpdate()
    {
        {
            // Obtenir l'entrée utilisateur
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // Déplacer l'objet vers l'avant/en arrière en fonction de l'entrée verticale
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * forwardInput);

            // Déplacer l'objet latéralement (gauche/droite) en fonction de l'entrée horizontale
            // transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed * horizontalInput);

            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.fixedDeltaTime);
        }
    }

    public Vector3 jump;
    public float jumpForce = 20.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
