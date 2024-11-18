using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteract : MonoBehaviour
{
    public int type;
    [SerializeField] NewTrash trashManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (trashManager.trashType == type) {
            //correct
        }
        else {
            //wrong
        }
        trashManager.MakeNewTrash();
    }
}
