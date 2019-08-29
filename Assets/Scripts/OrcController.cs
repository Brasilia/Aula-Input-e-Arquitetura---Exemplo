using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class OrcController : EnemyController
    {
        [Range(0, 1)]
        public float chance;


        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            Debug.Log("Starting orc controller");
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Util.Random.Test(chance))
            {
                Jump();
            }
        }

        
    }

}

