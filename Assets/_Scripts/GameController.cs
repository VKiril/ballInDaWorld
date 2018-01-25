using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public DataContainer data;

    public Sprite earth;
    public Sprite moon;
    public Sprite jupiter;

    public GameObject background;
    public GameObject ball;

    public Color[] colors;

    private Color JUPITER_COLOR = new Color(185f, 110f, 50f);
    private Color EARTH_COLOR = new Color(185f, 110f, 50f);
    private Color MOON_COLOR = new Color(185f, 110f, 50f);

    private Vector2 touchOrigin = -Vector2.one;
    private float forceValue = 70f;

    Vector2 force;


    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    void Start () {
        data.ballHits = 0;
        Init();

        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }
	
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            ApplyForce(target);
        }
#elif UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 target = touch.position;
            ApplyForce(target);
        }
#endif

        ball.GetComponent<Rigidbody2D>().AddForce(ball.GetComponent<Rigidbody2D>().velocity, ForceMode2D.Force);
    }

    private void ApplyForce(Vector2 target)
    {
        Vector3 newTarget = new Vector3(target.x, target.y, 0);
        newTarget = Camera.main.ScreenToWorldPoint(newTarget);
        float xForce = 0;

        if (newTarget.x > ball.transform.position.x)
            xForce = forceValue;
        else
            xForce = -forceValue;

        force = new Vector2(xForce, ball.GetComponent<Rigidbody2D>().velocity.y + 20f);
        ball.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
    }

    protected void Init()
    {
        ball.GetComponent<Rigidbody2D>().gravityScale = data.gravity;

        switch (data.planetName)
        {
            case Constants.MOON_STRING:
                background.GetComponent<SpriteRenderer>().sprite = moon;
                
                break;
            case Constants.EARTH_STRING:
                background.GetComponent<SpriteRenderer>().sprite = earth;
                break;
            case Constants.JUPITER_STRING:
                background.GetComponent<SpriteRenderer>().sprite = jupiter;
                break;
        }
    }

    private void OnApplicationQuit()
    {
        data.ballHits = 0;
    }
}
