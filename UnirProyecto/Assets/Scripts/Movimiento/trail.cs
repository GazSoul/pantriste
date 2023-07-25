using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{   
    public int trailn;
    public playermovement pmovement;
    [SerializeField]
    private GameObject t1, t2, t3, t4, t100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){
    }
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trail Nivel"+ trailn);
        pmovement.jumpqty = trailn;
        pmovement.jumpcalc = trailn;
        switch(trailn){
            case 1:
                t1.SetActive(true);
                t2.SetActive(false);
                t3.SetActive(false);
                t4.SetActive(false);
                t100.SetActive(false);
                break;
            case 2:
                t1.SetActive(false);
                t2.SetActive(true);
                t3.SetActive(false);
                t4.SetActive(false);
                t100.SetActive(false);
                break;
            case 3:
                t1.SetActive(false);
                t2.SetActive(false);
                t3.SetActive(true);
                t4.SetActive(false);
                t100.SetActive(false);
                break;
            case 4:
                t1.SetActive(false);
                t2.SetActive(false);
                t3.SetActive(false);
                t4.SetActive(true);
                t100.SetActive(false);
                break;
            case 100:
                t1.SetActive(false);
                t2.SetActive(false);
                t3.SetActive(false);
                t4.SetActive(false);
                t100.SetActive(true);
                break;
        }
    }
}   
