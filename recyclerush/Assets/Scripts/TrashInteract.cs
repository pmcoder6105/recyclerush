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

    void OnTriggerEnter(Collider collision) {
        if (trashManager.trashType == type) {
            //correct
        }
        else {
            //wrong
        }
        trashManager.MakeNewTrash();
        transform.root.GetComponent<TrashBin>().canClose = true;
    }
}
