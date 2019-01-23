using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PaddleBehavior : MonoBehaviour
{
    string input;
    private float Speed = 10f;
    private float computerSpeed = 6f;
    private bool isHuman;
    // Start is called before the first frame update
    void Start()
    {
    }
public virtual void isLeftPaddle(bool isLeft ){
    Vector2 position = Vector2.zero;
    isHuman = true;
    if(isLeft){
        input = "Paddle";
        position = new Vector2(gamePong.leftBound.x + transform.localScale.x, 0);
    }else{
        input = "Paddle2";
        position = new Vector2(gamePong.rightBound.x - transform.localScale.x, 0);
    }
    transform.position = position;
}
public void isMachine(){
    Vector2 position = Vector2.zero;
    isHuman = false;
    position = new Vector2(gamePong.rightBound.x - transform.localScale.x, 0);
    transform.position = position;
}
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isHuman){
            manualControl();
        }else{
            machineControl();
        }

    }

    void manualControl(){
        float displacement = Input.GetAxis(input)* Time.deltaTime * Speed;

        if((transform.position.y+(transform.localScale.y/2)) > gamePong.rightBound.y && displacement > 0 ){
            displacement = 0;
        }
        if((transform.position.y-(transform.localScale.y/2)) < gamePong.leftBound.y && displacement < 0 ){
            displacement = 0;
        }
                transform.Translate(displacement*Vector2.up);
    }
    void machineControl(){
        
float displacement = Time.deltaTime * computerSpeed*(gamePong.ballYLocation-transform.position.y);
        if((transform.position.y+(transform.localScale.y/2)) > gamePong.rightBound.y && displacement > 0 ){
            displacement = 0;
        }
        if((transform.position.y-(transform.localScale.y/2)) < gamePong.leftBound.y && displacement < 0 ){
            displacement = 0;
        }
transform.Translate(displacement*Vector2.up);

    }


}
