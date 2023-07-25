using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyDamage : MonoBehaviour
{
    public playermovement playermovement;
    [SerializeField] private int spikeDamage;
    public GameObject padre;
    //[SerializeField] private GameObject player;
    [SerializeField] private hpsystem _hpsystem;
    void Start(){

    }
    void Update(){
    }
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                doDamage();
            }
        }
    // Update is called once per frame
    void doDamage()
    {
        _hpsystem.hp = _hpsystem.hp - spikeDamage;
        if(_hpsystem.hp<=0){
            print("as morido");
        }
        _hpsystem.UpdateHealth();
        playermovement.damaged = true;
        padre.SetActive(false);
    }
}
