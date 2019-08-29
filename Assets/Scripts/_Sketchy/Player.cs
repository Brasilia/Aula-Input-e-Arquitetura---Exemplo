using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Attributes")]
    public float speed;
    public float jumpForce;
    public float shootVelocity;

    [System.Serializable]
    public struct Controls
    {
        //public KeyCode left;
        //public KeyCode right;
        public KeyCode jump;
        public KeyCode shoot;
    }

    [Header("Controls")]
    public Controls controls;

    [Header("References")]
    public Collider2D feet;
    public GameObject bulletPrefab;
    public Transform weaponTransform;


    private Rigidbody2D rb;
    private bool jump = false;

    private void Awake() //Quem chama este método?
    {
        rb = GetComponent<Rigidbody2D>(); //Como a Unity acha esse componente?
    }

    private void Update()
    {
        //Controls
        if (Input.GetKeyDown(controls.jump)) //Keypresses devem ser verificadas no Update, para evitar perda de input
        {
            jump = true;
        }
        if (Input.GetKeyDown(controls.shoot)){
            Shoot();
        }
    }

    private void FixedUpdate() //O fixed update deve fazer os updates de física (rigidbody) - e é razoável pegar o input analógico aqui
    {
        //Run
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(speed * horizontalInput, 0f)); //Adiciona força horizontal ao rigidbody
        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //Jump
        if (jump)
        {
            int hits = feet.Cast(Vector2.down, new RaycastHit2D[1], 0.1f);
            if (hits > 0)
            {
                rb.AddForce(jumpForce * Vector2.up);
            }
            jump = false;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = weaponTransform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = shootVelocity * transform.right;
    }

}
