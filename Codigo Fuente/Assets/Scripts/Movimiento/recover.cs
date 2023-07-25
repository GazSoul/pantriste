using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recover : MonoBehaviour
{
    public playermovement playermovement;
    [SerializeField] private int hpRec;
    //[SerializeField] private GameObject player;
    [SerializeField] private hpsystem _hpsystem;
    void Start(){

    }
    void Update(){
    }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                doRecover();
            }
        }
    // Update is called once per frame
    void doRecover()
    {
        _hpsystem.hp = _hpsystem.hp + hpRec;
        if(_hpsystem.hp > _hpsystem.hearts.Length){
            _hpsystem.hp = _hpsystem.hearts.Length;
        }
        _hpsystem.UpdateHealth();
        playermovement.RecieveRecover();
        gameObject.SetActive(false);
    }
}