using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherScript : MonoBehaviour
{
    bool moneyInside;
    bool moneyWashed;
    float timer;
    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void StartWash() {
        timer += Time.deltaTime;
        animate.SetBool("washing", moneyInside);
        if (timer >= 7) {
            moneyWashed = true;
            timer = 0;
            //show ready icon
        }
    }

    public void PickMoney() {
        moneyInside = false;
        moneyWashed = false;
        //turn idle again
    }

}
