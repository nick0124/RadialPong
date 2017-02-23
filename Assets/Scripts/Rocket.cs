using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float rotationSpeed = 2;
    public int speed = 2;

    public GameObject buttonsCollidersLeft;
    public GameObject buttonsCollidersRight;
    public GameObject buttonsUiLeft;
    public GameObject buttonsUiRight;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    public float angle;//угол ракетки
    public float finaAngle;//конечный угол ракетки
    public float gunRotationSpeed = 1;
    public float currentAng;//текущий угол ракетки
    public GameVariables gameVariables;//хранилеще игровых переменных

	// Use this for initialization
	void Start () {
        //учет местположения ракетки
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            rotationSpeed = Mathf.Abs(gameVariables.racketSpeed) * 1;
        else
            rotationSpeed = Mathf.Abs(gameVariables.racketSpeed) * -1;
	}
	
	// Update is called once per frame
	void Update () {

        KeyboardControlls();

        //учет выбраного управления
        switch (gameVariables.controllsMode)
        {
            case 1:
                buttonsUiLeft.SetActive(false);
                buttonsUiRight.SetActive(false);
                buttonsCollidersLeft.SetActive(true);
                buttonsCollidersRight.SetActive(true);
                //controlllsModTxt.text = "1 OLD BUTTONS";
                break;
                /*
            case 2:
                buttonsUiLeft.SetActive(true);
                buttonsUiRight.SetActive(true);
                buttonsCollidersLeft.SetActive(true);
                buttonsCollidersRight.SetActive(true);
                //controlllsModTxt.text = "2 NEW BUTTONS";
                break;
                 */
            case 2:
                OneTouch();//controlllsModTxt.text = "3 ONE TOUCH";
                break;
            case 3:
                FastRotationByTouch();//controlllsModTxt.text = "4 FAST BY TOUCH";
                break;
            default:
                buttonsUiLeft.SetActive(false);
                buttonsUiRight.SetActive(false);//controlllsModTxt.text = "OLD BUTTONS";
                break;
        }

        transform.eulerAngles += new Vector3(0, 0, gameVariables.menuRacketSpeed);
	}

    //управление с клавиатуры
    public void KeyboardControlls()
    {
        //учет местположения ракетки
        /*
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
                rotationSpeed = Mathf.Abs(rotationSpeed) * -1;
            else
                rotationSpeed = Mathf.Abs(rotationSpeed);
        }   
         */
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles -= new Vector3(0, 0, gameVariables.racketSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0, 0, gameVariables.racketSpeed - gameVariables.racketSpeed);
        }
    }

    //управление 1 нажатием
    public void OneTouch()
    {
        transform.eulerAngles += new Vector3(0, 0, gameVariables.racketSpeed);
        if (Input.GetMouseButtonDown(0))
            gameVariables.racketSpeed *= -1;
    }

    //мгновенный поворот с помощью нажатия
    public void FastRotationByTouch()
    {
        if (Input.GetMouseButton(0))
        {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 0.0f;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            Vector3 rotationVector = new Vector3(0, 0, angle - 90);
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    //медленный поворот с помощью нажатия(not work)
    public void SlowRotationByTouch()
    {
        if (Input.GetMouseButton(0))
        {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 0.0f;
            object_pos = Camera.main.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            finaAngle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            if (finaAngle < 0)
                finaAngle = 180 + (180 + (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg));
            if (currentAng < finaAngle)
            {
                if (currentAng + gunRotationSpeed >= finaAngle)
                {
                    currentAng = finaAngle;
                }
                else
                {
                    currentAng += gunRotationSpeed;
                }
            }

            if (currentAng > finaAngle)
            {
                if (currentAng - gunRotationSpeed <= finaAngle)
                {
                    currentAng = finaAngle;
                }
                else
                {
                    currentAng -= gunRotationSpeed;
                }
            }
            Vector3 rotationVector = new Vector3(0, 0, currentAng - 90);
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }

    //управлние с учетом местположения ракетки для UI(слишком запутывает игрока)
    public void CheckAngle()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            gameVariables.racketSpeed = Mathf.Abs(gameVariables.racketSpeed) * 1;
        else
            gameVariables.racketSpeed = Mathf.Abs(gameVariables.racketSpeed) * -1;
    }

    //для UI кнопок
    public void MoveRight()
    {
        transform.eulerAngles += new Vector3(0, 0, gameVariables.racketSpeed);
    }
    public void MoveLeft()
    {
        transform.eulerAngles -= new Vector3(0, 0, gameVariables.racketSpeed);
    }
}
