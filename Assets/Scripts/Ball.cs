using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    private int direction=1;//направление полета
    public Text scoreTxt;//счет
    private bool collided;//было ли столкновение
    public GameVariables gameVariables;//хранилеще игровых переменных
    public UIscript uiScript;

	// Use this for initialization
	void Start () 
    {
        //чтобы мячик летел вверх при 1 запуске
        direction = -1;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = new Vector3(0, gameVariables.ballSpeed * Time.deltaTime, 0);
        Vector3 pos = transform.position;
        transform.position += transform.rotation * velocity * direction;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //исправление бага со счетом
        if (coll.name.StartsWith("Falser"))
            collided = false;
        if(coll.name.StartsWith("racket"))
        {
            if (collided == false)
            {
                GetComponent<AudioSource>().Play();
                //увеличение сложности и очков
                IncreaseDifficultAndScore();
                //обновление UI
                uiScript.UpdateScore();
                //смена угла мяча, на угол объекта с которым столкнулись
                transform.rotation = coll.transform.rotation;
                //смена напраления
                direction = -1;
            }
            collided = true;
        }
    }

    //увеличение сложности и очков
    private void IncreaseDifficultAndScore()
    {
        //увеличение скорости вращения ракетки при каждом ударе
        if (gameVariables.racketSpeed < gameVariables.maxRacketSpeed)
            gameVariables.racketSpeed += gameVariables.increaseRacketSpeed;
        //увеличение скорости мячика при каждом ударе
        if (gameVariables.ballSpeed < gameVariables.maxBallSpeed)
            gameVariables.ballSpeed += gameVariables.increaseBallSpeed;
        //увеличение очков
        gameVariables.score += 1;
    }

    //
    public void Play()
    {
        transform.eulerAngles = new Vector3(0, 0, 180); ;
        gameVariables.ballSpeed = gameVariables.startBallSpeed;
    }
}
