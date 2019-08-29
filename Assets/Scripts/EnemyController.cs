using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController : MonoBehaviour
    {
        public float speed;
        public float jumpForce;

        protected Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        protected void Start()
        {
            Debug.Log("Starting enemy controller");
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected void Jump()
        {
            rb.AddForce(jumpForce * Vector2.up);
        }
    }
}

