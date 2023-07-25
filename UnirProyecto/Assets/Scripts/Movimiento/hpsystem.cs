using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpsystem : MonoBehaviour
{
    //public GameObject hpbar;
    muerte muerte;
    public int hp = 3;
    int mHp;
    [SerializeField] public Image[] hearts;
    // Start is called before the first frame update
    public Sprite contenedorVacio,contenedorLleno;
    void Start()
    {
        mHp = hp;
        UpdateHealth();
    }

    void Update()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    public void UpdateHealth(){

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < hp)
            {
                hearts[i].sprite = contenedorLleno;
            }
            else
            {
                hearts[i].sprite = contenedorVacio;
            }
        }
        if(hp<0){
            hp=0;
        }
        if(hp==0){
            //muerte.morir();
            SceneManager.LoadScene("Main Menu");
        }
        if(hp>mHp){
            print("Pito");
            hp=mHp;
        }
    }

}
