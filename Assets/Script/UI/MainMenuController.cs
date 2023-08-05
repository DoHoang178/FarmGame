using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject SettingMenuPref;
    [SerializeField] private GameObject RootUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(GameConstant.SCENE_GAMEPLAY);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    //public void Setting()
    //{
    //    GameObject gameSetting = Instantiate(SettingMenuPref, RootUI.transform);
    //}

}