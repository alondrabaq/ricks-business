using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour{
    
    // Start is called before the first frame update
    private SpriteRender theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    public void Start(){
        theSR = GetComponet<SpriteRenderer>();
        
    }

    // Update is called once per frame
    public void Update(){
        if(Input.GetKeyDown(keyToPress)){
            theSR.sprite = pressedImage;

        }
        if(Input.GetKeyUp(keyToPress)){
            theSR.sprite = defaultImage;
        }
        
    }
}
