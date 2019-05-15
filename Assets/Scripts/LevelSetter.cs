using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSetter {

	public void SetLevel(int level)
    {
        GetType().GetMethod("Level" + (level).ToString()).Invoke(this, null);
        PlayerPrefs.SetInt("this_level", level);
        PlayerPrefs.SetString("game_type", "campain");
        SceneManager.LoadScene("Camp_1");
    }

    public void Level1()
    {
        PlayerPrefs.SetInt("field_dimension_x", 4);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("field_dimension_x", 5);
        PlayerPrefs.SetInt("field_dimension_y", 6);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level3()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level4()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level5()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level6()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 6);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level7()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 3);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
    }

    public void Level8()
    {
        PlayerPrefs.SetInt("field_dimension_x", 4);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 2);
    }

    public void Level9()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 2);
    }

    public void Level10()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 6);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level11()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 1);
        PlayerPrefs.SetInt("player3_team", 2);
    }

    public void Level12()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.STUBBORN_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 1);
        PlayerPrefs.SetInt("player3_team", 2);
    }

    public void Level13()
    {
        PlayerPrefs.SetInt("field_dimension_x", 5);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level14()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
    }


    public void Level15()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level16()
    {
        PlayerPrefs.SetInt("field_dimension_x", 4);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 4);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 4);
    }

    public void Level17()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
    }

    public void Level18()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
    }

    public void Level19()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 5);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
        PlayerPrefs.SetInt("player5_team", 2);
    }

    public void Level20()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 2);

		PlayerPrefs.SetInt("player1_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.PLAYER_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level21()
    {
        PlayerPrefs.SetInt("field_dimension_x", 4);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.TROLL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
    }

    public void Level22()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
    }

    public void Level23()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 6);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.SELFISH_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level24()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 5);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.STUBBORN_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
        PlayerPrefs.SetInt("player5_team", 1);
    }

    public void Level25()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.SELFISH_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level26()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.MYSTERIOUS_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level27()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 5);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.MYSTERIOUS_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.TROLL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
        PlayerPrefs.SetInt("player5_team", 1);
    }

    public void Level28()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 5);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.MYSTERIOUS_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.TROLL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 1);
        PlayerPrefs.SetInt("player4_team", 2);
        PlayerPrefs.SetInt("player5_team", 1);
    }

    public void Level29()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 6);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.STUBBORN_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.MYSTERIOUS_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.DUMB_BOT_ID);
        PlayerPrefs.SetInt("player6_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 3);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 1);
        PlayerPrefs.SetInt("player5_team", 2);
        PlayerPrefs.SetInt("player6_team", 3);
    }

    public void Level30()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.MYSTERIOUS_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level31()
    {
        PlayerPrefs.SetInt("field_dimension_x", 4);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level32()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 6);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.MYSTERIOUS_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.ANNOYER_BOT_ID);
        PlayerPrefs.SetInt("player6_player_type", GameController.THOUGHTFUL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 3);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 1);
        PlayerPrefs.SetInt("player5_team", 2);
        PlayerPrefs.SetInt("player6_team", 3);
    }

    public void Level33()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.MYSTERIOUS_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 4);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 4);
    }

    public void Level34()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 6);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 4);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 4);
    }

    public void Level35()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

    public void Level36()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 5);

        PlayerPrefs.SetInt("players_number", 3);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.NORMAL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.DUMB_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 2);
    }

    public void Level37()
    {
        PlayerPrefs.SetInt("field_dimension_x", 6);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 4);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.STUBBORN_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.NORMAL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 2);
        PlayerPrefs.SetInt("player4_team", 2);
    }

    public void Level38()
    {
        PlayerPrefs.SetInt("field_dimension_x", 7);
        PlayerPrefs.SetInt("field_dimension_y", 7);

        PlayerPrefs.SetInt("players_number", 6);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.TROLL_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.NORMAL_BOT_ID);
        PlayerPrefs.SetInt("player6_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 3);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 3);
        PlayerPrefs.SetInt("player4_team", 1);
        PlayerPrefs.SetInt("player5_team", 2);
        PlayerPrefs.SetInt("player6_team", 3);
    }

    public void Level39()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 9);

        PlayerPrefs.SetInt("players_number", 6);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.THOUGHTFUL_BOT_ID);
        PlayerPrefs.SetInt("player3_player_type", GameController.SELFISH_BOT_ID);
        PlayerPrefs.SetInt("player4_player_type", GameController.MYSTERIOUS_BOT_ID);
        PlayerPrefs.SetInt("player5_player_type", GameController.NORMAL_BOT_ID);
        PlayerPrefs.SetInt("player6_player_type", GameController.ANNOYER_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
        PlayerPrefs.SetInt("player3_team", 2);
        PlayerPrefs.SetInt("player4_team", 2);
        PlayerPrefs.SetInt("player5_team", 2);
        PlayerPrefs.SetInt("player6_team", 2);
    }

    public void Level40()
    {
        PlayerPrefs.SetInt("field_dimension_x", 8);
        PlayerPrefs.SetInt("field_dimension_y", 8);

        PlayerPrefs.SetInt("players_number", 2);

        PlayerPrefs.SetInt("player1_player_type", GameController.PLAYER_ID);
        PlayerPrefs.SetInt("player2_player_type", GameController.NORMAL_BOT_ID);

        PlayerPrefs.SetInt("teams_number", 2);

        PlayerPrefs.SetInt("player1_team", 1);
        PlayerPrefs.SetInt("player2_team", 2);
    }

}
