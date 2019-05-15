using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StartButton : MonoBehaviour
{
    public GameObject[] level;

    public Button back;
    public Button next;

    private int _page;

    public const int PAGE_NUM = 1;

    private static readonly LevelSetter LS = new LevelSetter();

    void Start()
    {
        back.interactable = false;
        _page = 0;
        for (int i = 20; i < PlayerPrefs.GetInt("this_level"); i+=20)
        {
            Next();
        }
        unlock();
    }

    private void unlock()
    {
        for (int i = 0; i < 20; i++)
        {
            level[i].GetComponent<Button>().interactable = false;
            level[i].GetComponentInChildren<Text>().text = (1 + i + _page * 20).ToString();
        }
        int currentLevel = PlayerPrefs.GetInt("progress") - 20 *_page;
        if (currentLevel >= 20)
            currentLevel = 19;
        for (int i = 0; i < currentLevel + 1; i++)
            level[i].GetComponent<Button>().interactable = true;
    }

    public void Play(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Back()
    {
        if(--_page == 0)
            back.interactable = false;
        next.interactable = true;
        unlock();
    }

    public void Next()
    {
        if (++_page == PAGE_NUM)
            next.interactable = false;
        back.interactable = true;
        unlock();
    }


    public void StartCampanha(string ncamp)
    {
        LS.SetLevel(int.Parse(ncamp) + _page * 20);
    }


    
}