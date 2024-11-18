using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{

    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        Debug.Log("entered collision with " + collision.gameObject.name);

        if (collision.gameObject.tag == "Trash") {
            animator.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Trash") {
            animator.SetBool("isOpen", false);
        }
    }
}
