using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomGame : MonoBehaviour
{

    private int players;

    public Dropdown PlayerType1;
    public Text PlayerTypeTxt1;
    public Dropdown PlayerTeam1;

    public Dropdown PlayerType2;
    public Text PlayerTypeTxt2;
    public Dropdown PlayerTeam2;

    public Dropdown PlayerType3;
    public Text PlayerTypeTxt3;
    public Dropdown PlayerTeam3;

    public Dropdown PlayerType4;
    public Text PlayerTypeTxt4;
    public Dropdown PlayerTeam4;

    public Dropdown PlayerType5;
    public Text PlayerTypeTxt5;
    public Dropdown PlayerTeam5;

    public Dropdown PlayerType6;
    public Text PlayerTypeTxt6;
    public Dropdown PlayerTeam6;

    public Dropdown Width;
    public Dropdown Height;

    public Button AddPlayerB;
    public Button RemovePlayerB;

    public Button StartButton;

    void Start()
    {
        players = 2;

        foreach (var item in new Transform[] { PlayerTeam3.GetComponent<Transform>(), PlayerType3.GetComponent<Transform>(), PlayerTypeTxt3.GetComponent<Transform>(),
                                               PlayerTeam4.GetComponent<Transform>(), PlayerType4.GetComponent<Transform>(), PlayerTypeTxt4.GetComponent<Transform>(),
                                               PlayerTeam5.GetComponent<Transform>(), PlayerType5.GetComponent<Transform>(), PlayerTypeTxt5.GetComponent<Transform>(),
                                               PlayerTeam6.GetComponent<Transform>(), PlayerType6.GetComponent<Transform>(), PlayerTypeTxt6.GetComponent<Transform>()})
            item.position = new Vector3(999, item.position.y, item.position.z);

        RemovePlayerB.interactable = false;
        StartButton.interactable = false;
    }

    public void AddPalyer()
    {
        players++;
        RemovePlayerB.interactable = true;
        switch (players)
        {
            case 3:
                PlayerTeam3.GetComponent<Transform>().position = new Vector3(PlayerTeam1.GetComponent<Transform>().position.x, PlayerTeam3.GetComponent<Transform>().position.y, PlayerTeam3.GetComponent<Transform>().position.z);
                PlayerType3.GetComponent<Transform>().position = new Vector3(PlayerType1.GetComponent<Transform>().position.x, PlayerType3.GetComponent<Transform>().position.y, PlayerType3.GetComponent<Transform>().position.z);
                PlayerTypeTxt3.GetComponent<Transform>().position = new Vector3(PlayerTypeTxt1.GetComponent<Transform>().position.x, PlayerTypeTxt3.GetComponent<Transform>().position.y, PlayerTypeTxt3.GetComponent<Transform>().position.z);
                break;
            case 4:
                PlayerTeam4.GetComponent<Transform>().position = new Vector3(PlayerTeam1.GetComponent<Transform>().position.x, PlayerTeam4.GetComponent<Transform>().position.y, PlayerTeam4.GetComponent<Transform>().position.z);
                PlayerType4.GetComponent<Transform>().position = new Vector3(PlayerType1.GetComponent<Transform>().position.x, PlayerType4.GetComponent<Transform>().position.y, PlayerType4.GetComponent<Transform>().position.z);
                PlayerTypeTxt4.GetComponent<Transform>().position = new Vector3(PlayerTypeTxt1.GetComponent<Transform>().position.x, PlayerTypeTxt4.GetComponent<Transform>().position.y, PlayerTypeTxt4.GetComponent<Transform>().position.z);
                break;
            case 5:
                PlayerTeam5.GetComponent<Transform>().position = new Vector3(PlayerTeam1.GetComponent<Transform>().position.x, PlayerTeam5.GetComponent<Transform>().position.y, PlayerTeam5.GetComponent<Transform>().position.z);
                PlayerType5.GetComponent<Transform>().position = new Vector3(PlayerType1.GetComponent<Transform>().position.x, PlayerType5.GetComponent<Transform>().position.y, PlayerType5.GetComponent<Transform>().position.z);
                PlayerTypeTxt5.GetComponent<Transform>().position = new Vector3(PlayerTypeTxt1.GetComponent<Transform>().position.x, PlayerTypeTxt5.GetComponent<Transform>().position.y, PlayerTypeTxt5.GetComponent<Transform>().position.z);
                break;
            case 6:
                PlayerTeam6.GetComponent<Transform>().position = new Vector3(PlayerTeam1.GetComponent<Transform>().position.x, PlayerTeam6.GetComponent<Transform>().position.y, PlayerTeam6.GetComponent<Transform>().position.z);
                PlayerType6.GetComponent<Transform>().position = new Vector3(PlayerType1.GetComponent<Transform>().position.x, PlayerType6.GetComponent<Transform>().position.y, PlayerType6.GetComponent<Transform>().position.z);
                PlayerTypeTxt6.GetComponent<Transform>().position = new Vector3(PlayerTypeTxt1.GetComponent<Transform>().position.x, PlayerTypeTxt6.GetComponent<Transform>().position.y, PlayerTypeTxt6.GetComponent<Transform>().position.z);
                AddPlayerB.interactable = false;
                break;
        }
        CanStart();
    }

    public void RemovePalyer()
    {
        AddPlayerB.interactable = true;
        switch (players)
        {
            case 3:
                PlayerTeam3.GetComponent<Transform>().position = new Vector3(999, PlayerTeam3.GetComponent<Transform>().position.y, PlayerTeam3.GetComponent<Transform>().position.z);
                PlayerType3.GetComponent<Transform>().position = new Vector3(999, PlayerType3.GetComponent<Transform>().position.y, PlayerType3.GetComponent<Transform>().position.z);
                PlayerTypeTxt3.GetComponent<Transform>().position = new Vector3(999, PlayerTypeTxt3.GetComponent<Transform>().position.y, PlayerTypeTxt3.GetComponent<Transform>().position.z);
                RemovePlayerB.interactable = false;
                break;
            case 4:
                PlayerTeam4.GetComponent<Transform>().position = new Vector3(999, PlayerTeam4.GetComponent<Transform>().position.y, PlayerTeam4.GetComponent<Transform>().position.z);
                PlayerType4.GetComponent<Transform>().position = new Vector3(999, PlayerType4.GetComponent<Transform>().position.y, PlayerType4.GetComponent<Transform>().position.z);
                PlayerTypeTxt4.GetComponent<Transform>().position = new Vector3(999, PlayerTypeTxt4.GetComponent<Transform>().position.y, PlayerTypeTxt4.GetComponent<Transform>().position.z);
                break;
            case 5:
                PlayerTeam5.GetComponent<Transform>().position = new Vector3(999, PlayerTeam5.GetComponent<Transform>().position.y, PlayerTeam5.GetComponent<Transform>().position.z);
                PlayerType5.GetComponent<Transform>().position = new Vector3(999, PlayerType5.GetComponent<Transform>().position.y, PlayerType5.GetComponent<Transform>().position.z);
                PlayerTypeTxt5.GetComponent<Transform>().position = new Vector3(999, PlayerTypeTxt5.GetComponent<Transform>().position.y, PlayerTypeTxt5.GetComponent<Transform>().position.z);
                break;
            case 6:
                PlayerTeam6.GetComponent<Transform>().position = new Vector3(999, PlayerTeam6.GetComponent<Transform>().position.y, PlayerTeam6.GetComponent<Transform>().position.z);
                PlayerType6.GetComponent<Transform>().position = new Vector3(999, PlayerType6.GetComponent<Transform>().position.y, PlayerType6.GetComponent<Transform>().position.z);
                PlayerTypeTxt6.GetComponent<Transform>().position = new Vector3(999, PlayerTypeTxt6.GetComponent<Transform>().position.y, PlayerTypeTxt6.GetComponent<Transform>().position.z);
                break;
        }
        players--;
        CanStart();
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CanStart()
    {
        int[] values = new int[] { PlayerTeam1.value, PlayerTeam2.value, PlayerTeam3.value, PlayerTeam4.value, PlayerTeam5.value, PlayerTeam6.value };
        bool[] teams = new bool[6];
        for (int i = 0; i < players; i++)
        {
            teams[values[i]] = true;
        }
        int cont = 0;
        foreach (var item in teams)
        {
            if (item)
            {
                cont++;
                if (cont >= 2)
                {
                    StartButton.interactable = true;
                    return;
                }
            }
        }
        StartButton.interactable = false;
    }


    public void StartGame()
    {
        PlayerPrefs.SetString("game_type", "custom");

        PlayerPrefs.SetInt("this_level", -1);

        PlayerPrefs.SetInt("field_dimension_x", Width.value+4);
        PlayerPrefs.SetInt("field_dimension_y", Height.value+5);

        PlayerPrefs.SetInt("players_number", players);

        PlayerPrefs.SetInt("player1_player_type", PlayerType1.value);
        PlayerPrefs.SetInt("player2_player_type", PlayerType2.value);
        PlayerPrefs.SetInt("player3_player_type", PlayerType3.value);
        PlayerPrefs.SetInt("player4_player_type", PlayerType4.value);
        PlayerPrefs.SetInt("player5_player_type", PlayerType5.value);
        PlayerPrefs.SetInt("player6_player_type", PlayerType6.value);

        PlayerPrefs.SetInt("teams_number", 6);

        PlayerPrefs.SetInt("player1_team", PlayerTeam1.value + 1);
        PlayerPrefs.SetInt("player2_team", PlayerTeam2.value + 1);
        PlayerPrefs.SetInt("player3_team", PlayerTeam3.value + 1);
        PlayerPrefs.SetInt("player4_team", PlayerTeam4.value + 1);
        PlayerPrefs.SetInt("player5_team", PlayerTeam5.value + 1);
        PlayerPrefs.SetInt("player6_team", PlayerTeam6.value + 1);

        SceneManager.LoadScene("Camp_1");
    }
}
