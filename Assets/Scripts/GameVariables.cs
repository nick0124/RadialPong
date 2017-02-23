using UnityEngine;
using System.Collections;

public class GameVariables : MonoBehaviour {

    public float ballSpeed;//скорость мячика
    public float startBallSpeed =6;//стартовая скорость мяча
    public float maxBallSpeed = 14;//максимальная скорость мяча
    public float increaseBallSpeed = 0.2f;//скорость с которой увеличивается скорость мячика

    public float racketSpeed;//скорость поворота рокетки
    public float startRacketSpeed=2;//стартовая скорость ракетки
    public float increaseRacketSpeed=0.1f;//скорость с которой увеличивается скорость ракетки
    public float maxRacketSpeed =10;//максмальная скорость поворота рокетки
    public float menuRacketSpeed=2;//скорость ракетки в меню
    public int score;//счет

    public int controllsMode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
