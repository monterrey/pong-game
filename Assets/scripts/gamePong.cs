using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePong : MonoBehaviour
{
    private int goal ;
    private int scoreP1;
    private int scoreP2;
    public Text player1Score;
    public Text goalText;
    BallMove myball;
    
public BallMove ball;
public PaddleBehavior player;
   public static Vector2 leftBound;
   public static Vector2 rightBound;
   public static float ballYLocation;
    // Start is called before the first frame update
    void Start()
    {
        goal = 5;
        goalText.text = "Goal : "+goal;
        scoreP1 = 0;
        scoreP2 = 0;
        leftBound = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        rightBound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
    myball = Instantiate(ball);
    ballYLocation = myball.getYLoc();
   PaddleBehavior player1 = Instantiate(player);
   PaddleBehavior player2 = Instantiate(player);
   player2.isMachine();
   player1.isLeftPaddle(true);
   
    }
public void updateScore(bool p1Scored){
    if(p1Scored){
        
    scoreP1 += 1;
        if(scoreP1 >= goal){
            player1Score.text = " Player 1 won ";
        Quit();
        }
    }else{
        scoreP2 += 1;
        if(scoreP2 >= goal){
            player1Score.text = " Player 1 won ";
        Quit();
        }
    }
    player1Score.text = "You : " + scoreP1 + " Opponent " + scoreP2;
    myball = Instantiate(ball);
}
    // Update is called once per frame
    void Update()
    {
        
    }
        public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}