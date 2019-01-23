using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMove : MonoBehaviour
{
    private gamePong myGame;
    private float ballSpeed = 10f;
    private float ballRadius ;
    Vector2 ballDirection = new Vector2(1,1).normalized;

    // Start is called before the first frame update
    void Start()
    {
        float randX =Random.Range(-5,5);
        float randY = Random.Range(-2,2);
        if(randX == 0){
            randX += 1;
        }
        if(randY == 0){
            randY += 1;
        }

        ballDirection = new Vector2(randX,randY).normalized;

        transform.position = new Vector2(0,0);
        GameObject myGameObj = GameObject.FindWithTag("GameController");
        if(myGameObj != null){
            myGame = myGameObj.GetComponent<gamePong>();
        }
        ballRadius = transform.localScale.y;
    }
public float getYLoc(){
    return transform.position.y;
}
    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y + ballRadius > gamePong.rightBound.y && ballDirection.y > 0){
            ballDirection.y = -ballDirection.y;
        }
        if(transform.position.y - ballRadius < gamePong.leftBound.y && ballDirection.y < 0){
            ballDirection.y = -ballDirection.y;
        }

        if(transform.position.x - ballRadius > gamePong.rightBound.x && ballDirection.x > 0){
            myGame.updateScore(false);
            Destroy(gameObject);
        }
        if(transform.position.x + ballRadius < gamePong.leftBound.x && ballDirection.x < 0){
            myGame.updateScore(true);
            Destroy(gameObject);
        }
        
        transform.Translate(ballDirection*ballSpeed * Time.deltaTime,Camera.main.transform); 
        gamePong.ballYLocation = transform.position.y;
    }



    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("mes");
        ballDirection.x = - ballDirection.x;
        //Destroy(gameObject);
    }
}
