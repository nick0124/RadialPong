using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {

    public GameObject rocket;//ракетка
    public GameObject menu;//UI стартовое меню
    public GameObject game;//UI интерфейс игры
    public GameObject youSure;//UI меню обнуления счета
    public GameObject controllsMenu;//
    public Text scoreTxt;//UI счет в игре
    public Text bestScoreTxt;//UI лучший счет
    public GameVariables gameVariables;//хранилеще игровых переменных

    //что то для смены управления
    public Text controlllsModTxt;
    int i = 0;

	// Use this for initialization
	void Start () 
    {

        gameVariables.racketSpeed = gameVariables.startRacketSpeed;
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
        controlllsModTxt.text = "1 OLD BUTTONS";
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //начать игру
    public void Play()
    {
        menu.SetActive(false);
        game.SetActive(true);
        youSure.SetActive(false);
        controllsMenu.SetActive(false);
        gameVariables.menuRacketSpeed = 0;
        rocket.transform.eulerAngles = Vector3.zero;
    }

    //кнопки меню сброса очков
    public void Resset()
    {
        menu.SetActive(false);
        game.SetActive(false);
        youSure.SetActive(true);
        controllsMenu.SetActive(false);
    }
    public void YouSureYes()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
        menu.SetActive(true);
        game.SetActive(false);
        youSure.SetActive(false);
        controllsMenu.SetActive(false);
    }
    public void ToMenu()
    {
        menu.SetActive(true);
        game.SetActive(false);
        youSure.SetActive(false);
        controllsMenu.SetActive(false);
    }

    //выход из игры
    public void Exit()
    {
        Application.Quit();
    }

    //меню настроек упраления
    public void ControllsMenu()
    {
        menu.SetActive(false);
        game.SetActive(false);
        youSure.SetActive(false);
        controllsMenu.SetActive(true);
    }
    public void ControlsUp()
    {
        //смена значения счеткика
        if (i < 3)
            i++;
        else
            i = 1;
        //обновление счетчика
        gameVariables.controllsMode = i;
        //обновление текста
        switch (i)
        {
            case 1:
                controlllsModTxt.text = "1 OLD BUTTONS";
                break;
                /*
            case 2:
                controlllsModTxt.text = "2 NEW BUTTONS";
                break;
                 */
            case 2:
                controlllsModTxt.text = "2 ONE TOUCH";
                break;
            case 3:
                controlllsModTxt.text = "3 FAST BY TOUCH";
                break;
            default:
                controlllsModTxt.text = "1 OLD BUTTONS";
                break;
        }
    }
    public void ControlsDown()
    {
        //смена значения счеткика
        if (i < 2)
            i = 3;
        else
            i--;
        //обновление счетчика
        gameVariables.controllsMode = i;
        //обновление текста
        switch (i)
        {
            case 1:
                controlllsModTxt.text = "1 OLD BUTTONS";
                break;
                /*
            case 2:
                controlllsModTxt.text = "2 NEW BUTTONS";
                break;
                 */
            case 2:
                controlllsModTxt.text = "2 ONE TOUCH";
                break;
            case 3:
                controlllsModTxt.text = "3 FAST BY TOUCH";
                break;
            default:
                controlllsModTxt.text = "1 OLD BUTTONS";
                break;
        }
    }

    public void UpdateScore()
    {
        scoreTxt.text = gameVariables.score.ToString();
    }

    //проигрыш
    void OnTriggerEnter2D(Collider2D coll)
    {
        //если лучший счет меньше текущего счета, одновляем лучший счет
        if (PlayerPrefs.GetInt("BestScore") < gameVariables.score)
            PlayerPrefs.SetInt("BestScore", gameVariables.score);
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();

        menu.SetActive(true);
        game.SetActive(false);
        youSure.SetActive(false);

        coll.transform.position = Vector2.zero;//обнуление позиции мяча
        gameVariables.ballSpeed = 0;//обнуление скорости мяча 

        gameVariables.score = 0;//обнуление счета
        scoreTxt.text = "0";

        gameVariables.menuRacketSpeed = 2;//задавем скорость вращения ракетки в меню
        gameVariables.racketSpeed = gameVariables.startRacketSpeed;//сбрасываем скорость вращения ракетки
    }
}
