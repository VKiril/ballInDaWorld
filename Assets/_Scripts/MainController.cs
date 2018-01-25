using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public Text ballHitsText;
    public DataContainer data;

    private void Start()
    {
        ballHitsText.text = "BallHits: " + data.ballHits;
    }

    public void PressButton(string planeName)
    {
        GetGravityByPlanetName(planeName);
        data.planetName = planeName;
        data.ballHits = 0;

        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    protected void GetGravityByPlanetName(string name)
    {
        switch(name)
        {
            case Constants.MOON_STRING:
                data.gravity = Constants.MOON_GRAVITY;
                break;
            case Constants.EARTH_STRING:
                data.gravity = Constants.EARTH_GRAVITY;
                break;
            case Constants.JUPITER_STRING:
                data.gravity = Constants.JUPITER_GRAVITY;
                break;
        }
    }

    private void OnApplicationQuit()
    {
        data.ballHits = 0;
    }
}
