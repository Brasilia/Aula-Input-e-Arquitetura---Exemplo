using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 4;


        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetInput();
        }

        void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jumpForce * Vector2.up);
                Debug.Log("Jump");
            }
        }
    }
}

