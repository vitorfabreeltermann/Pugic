using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Classe responsável pelo controle do fluxo de jogo
public class GameController : MonoBehaviour
{
    public Text SP1, SP2;
    public Button BSP;

	public Text Error;

    private readonly System.Random _random = new System.Random();

    public int ThisLevel { get; private set; }

    // IDs dos tipos de jogador
    public const int PLAYER_ID = 0;
    public const int DUMB_BOT_ID = 1;
    public const int NORMAL_BOT_ID = 2;
    public const int ANNOYER_BOT_ID = 3;
    public const int SELFISH_BOT_ID = 4;
    public const int STUBBORN_BOT_ID = 5;
    public const int TROLL_BOT_ID = 6;
    public const int MYSTERIOUS_BOT_ID = 7;
    public const int THOUGHTFUL_BOT_ID = 8;

    // Cores das bolinhas
    private static readonly Color[] PLAYERS_COLORS = new Color[] {
                                                    new Color(0.588f, 0.204f, 0.204f), //None - Default
                                                    new Color(1f, 0f, 0f), //Player 1 - Vermelho
                                                    new Color(0f, 1f, 0f), //Player 2 - Verde
                                                    new Color(0f, 0f, 1f), //Player 3 - Azul
                                                    new Color(1f, 1f, 0f), //Player 4 - Amarelo
                                                    new Color(1f, 0f, 1f), //Player 5 - Magenta
                                                    new Color(0f, 1f, 1f)  //Player 6 - Ciano
                                                                };
    // Jogadores
    private PlayerController[] _playersControl;

    // Times
    private TeamController[] _teamsControl;

    // Quantidades de bolinhas no total
    public int BallsCount { get; private set; }
    // Quantidades de bolinhas no eixo Y
    public int BallsCountY { get; private set; }
    // Quantidades de bolinhas no eixo X
    public int BallsCountX { get; private set; }

    // Variável responsável por dizer se o jogo está esperando uma ação de um jogador
    public bool WaitingInput { get; set; }

    // Variável responsável por dizer se a partida foi finalizada
    private bool _gameOver;

    // Quantidade de times
    private int _teamsNumber;

    // Quantidade de jogadores
    private int _playersNumber;

    // Número do jogador atual
    private int _currentPlayer;

    // Objeto para indicar de quem é o turno pela cor
    public BallController ColorTurn;
    // objeto para posicionar o contador de turno
    public GameObject ContadorDeTurno;

    // Posição da camera do jogo
    public GameObject Camera;
    public Transform Photo;
    // Bolinhas
    private GameObject[][] _balls;
    // Objeto de criação das bolinhas
    public GameObject ballPrefab;

    //pré-construidos para formação do time ^^
    public GameObject FormationTeamPrefab;
    // Variável usada para causar o delay entre as jogadas
    private float _time;

    private bool _started = false;

	//Variável para repetir jogada na fase 25
	private bool repeat = false;

    // Inicialização do jogo
    void Start()
    {
        ThisLevel = PlayerPrefs.GetInt("this_level");
        SP2.text = "";
        switch (ThisLevel)
        {
            case 5:
                SP2.text += "- Random generated level";
                break;
            case 10:
				SP2.text += "- Each player can't select pieces that doesn't have an owner\n"+
                            "- If any player have no pieces at any time during this level, this player will lose";
                break;
            case 15:
				SP2.text += "- You must have at least one piece at any time during this level";
                break;
            case 20:
				SP2.text += "- You control your opponent\n"+
                            "- Your opponent controls you";
                break;
			case 25:
				SP2.text += "- Your opponent plays twice in a row";
                break;
            case 30:
				SP2.text += "- ???";
                break;
            case 35:
                SP2.text += "- You can't have less pieces than your opponent at any time during this level";
                break;
            case 40:
                SP2.text += "- The position of the pieces was shuffled";
                break;
            default:
                StartGame();
                break;
        }
    }

    public void StartGame()
    {
        SP1.GetComponent<Transform>().position = new Vector3(999, 999, -999);
		SP2.GetComponent<Transform>().position = new Vector3(999, 999, -999);
		BSP.GetComponent<Transform>().position = new Vector3(999, 999, -999);

        _time = 0;

        WaitingInput = false;

        // Busca o tamanho do mapa (quantidade de bolinhas em cada eixo)
        BallsCountX = PlayerPrefs.GetInt("field_dimension_x");
        BallsCountY = PlayerPrefs.GetInt("field_dimension_y");
        BallsCount = (BallsCountX * BallsCountY);

        // Adapta a posição da camera de acordo com o tamanho do mapa e a posição da foto.
        Camera.transform.position = new Vector3(((1.5f * BallsCountX) - 1.5f), ((1.5f * BallsCountY) - 1.5f), ((-3 * (BallsCountX >= BallsCountY ? BallsCountX : BallsCountY)) + 1));
        // Adapta a posição do contador de acordo com a camera
        ContadorDeTurno.transform.position = new Vector3((BallsCountX * 1.5f) - 1.5f, ((BallsCountY * 3f) + 3), (-2f));
        ContadorDeTurno.transform.localScale = new Vector3((BallsCountY * .05f) + 0.95f, ((BallsCountY * .05f) + 0.95f), (1f));
        Photo.position = new Vector3(BallsCountX + 1, BallsCountY + 0, Photo.position.z);
        Camera.GetComponent<Camera>().orthographicSize = 9 + (int)(BallsCountX >= BallsCountY ? BallsCountX * 1.8 : BallsCountY * 1.5);

        // Início da criação dos times
        _teamsNumber = PlayerPrefs.GetInt("teams_number");
        _teamsControl = new TeamController[_teamsNumber + 1];

        for (int i = 0; i <= _teamsNumber; i++)
            _teamsControl[i] = new TeamController(i);
        // Fim da criação dos times

        // Início da criação dos jogadores
        _playersNumber = PlayerPrefs.GetInt("players_number");
        _playersControl = new PlayerController[_playersNumber + 1];

        _playersControl[0] = new PlayerController(0, this, null, PLAYERS_COLORS[0], _teamsControl[0]);
        for (int i = 1; i <= _playersNumber; i++)
        {
            int playerType = PlayerPrefs.GetInt(string.Format("player{0}_player_type", i));
            TeamController team = _teamsControl[PlayerPrefs.GetInt(string.Format("player{0}_team", i))];
            BotBaseController bot;
            if (playerType == PLAYER_ID)
                bot = null;
            else if (playerType == DUMB_BOT_ID)
                bot = new DumbBotController(this);
            else if (playerType == NORMAL_BOT_ID)
                bot = new NormalBotController(this);
            else if (playerType == ANNOYER_BOT_ID)
                bot = new AnnoyerBotController(this);
            else if (playerType == SELFISH_BOT_ID)
                bot = new SelfishBotController(this);
            else if (playerType == STUBBORN_BOT_ID)
                bot = new StubbornBotController(this);
            else if (playerType == TROLL_BOT_ID)
                bot = new TrollBotController(this);
            else if (playerType == MYSTERIOUS_BOT_ID)
                bot = new MysteriousBotController(this);
            else// if (playerType == THOUGHTFUL_BOT_ID)
                bot = new ThoughtfulBotController(this);
            _playersControl[i] = new PlayerController(i, this, bot, PLAYERS_COLORS[i], team);
        }
        // Fim da criação dos jogadores
        _currentPlayer = 1;
        // Início da criação das bolinhas
        _balls = new GameObject[BallsCountX][];
        for (int i = 0; i < _balls.Length; i++)
        {
            _balls[i] = new GameObject[BallsCountY];
            for (int j = 0; j < _balls[i].Length; j++)
            {
                _balls[i][j] = Instantiate(ballPrefab);
                BallController ball = _balls[i][j].GetComponent<BallController>();
                int neighborNum = 2;
                if (i != 0 && i != _balls.Length - 1)
                    neighborNum++;
                if (j != 0 && j != _balls[i].Length - 1)
                    neighborNum++;
                ball.StartValues(neighborNum, i, j, this, _playersControl[0]);
                _balls[i][j].GetComponent<Transform>().position = new Vector3(3f * i, 3f * j, -2);
            }
        }
        //Fim da criação das bolinhas
        ChanceColorTurnPlayer(GetCurrentPlayer());
        TeamFormation(_teamsControl);

        switch (ThisLevel)
        {
			case 5:
				int[,] map = new int[8,8];
				for (int i = 0; i < 1; i++) {
					for (int j = 0; j < 8; j++) {
						map [i,j] = 0;
					}
				}
				for (int i = 1; i < 2; i++) {
					for (int j = 0; j < 8; j++) {
						map [i,j] = 1;
					}
				}
				for (int i = 2; i < 6; i++) {
					for (int j = 0; j < 8; j++) {
						map [i,j] = 2;
					}
				}
				for (int i = 6; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						int r = _random.Next (0, 5);
						map [i, j] =  r > 2 ? 2 : r;
					}
				}
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						_balls [i] [j].GetComponent<BallController>().ChangeOwner(map[i,j]);
					}
				}
				for (int i = 0; i < 1000; i++) {
					int x1 = _random.Next (0, 8), y1 = _random.Next (0, 8), x2 =_random.Next (0, 8), y2 = _random.Next(0, 8);
					int oldOwner1 = _balls[x1][y1].GetComponent<BallController>().PlayerOwner.PlayerNumber,
						oldOwner2 = _balls[x2][y2].GetComponent<BallController>().PlayerOwner.PlayerNumber;
					_balls[x1][y1].GetComponent<BallController>().ChangeOwner(oldOwner2);
					_balls[x2][y2].GetComponent<BallController>().ChangeOwner(oldOwner1);
				}
				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						BallController currBall = _balls[i][j].GetComponent<BallController>();
						int r = _random.Next (0, 6);
						for (int k = 6 - currBall.NeighborNumber; k < r; k++) {
							currBall.AddPoint ();
						}
					}
				}
				break;
            case 10:
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        _balls[i][j].GetComponent<BallController>().ChangeOwner(1);
                        _balls[5 - i][5 - j].GetComponent<BallController>().ChangeOwner(2);
                    }
                }
                break;
            case 15:
                _balls[2][3].GetComponent<BallController>().ChangeOwner(1);
                _balls[3][3].GetComponent<BallController>().ChangeOwner(2);
                break;
            /*case 25:
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        _balls[i][j].GetComponent<BallController>().ChangeOwner(1);
                        _balls[6 - i][6 - j].GetComponent<BallController>().ChangeOwner(1);
                        _balls[6 - i][j].GetComponent<BallController>().ChangeOwner(2);
                        _balls[6 - i][j].GetComponent<BallController>().AddPoint();
                        _balls[i][6 - j].GetComponent<BallController>().ChangeOwner(2);
                        _balls[i][6 - j].GetComponent<BallController>().AddPoint();
                    }
                    _balls[i][3].GetComponent<BallController>().ChangeOwner(2);
                    _balls[3][i].GetComponent<BallController>().ChangeOwner(2);
                    _balls[6 - i][3].GetComponent<BallController>().ChangeOwner(2);
                    _balls[3][6 - i].GetComponent<BallController>().ChangeOwner(2);
                    for (int k = 0; k < 2; k++)
                    {
                        _balls[i][3].GetComponent<BallController>().AddPoint();
                        _balls[3][i].GetComponent<BallController>().AddPoint();
                        _balls[6 - i][3].GetComponent<BallController>().AddPoint();
                        _balls[3][6 - i].GetComponent<BallController>().AddPoint();
                    }
                }
                _balls[3][3].GetComponent<BallController>().ChangeOwner(2);
                for (int i = 0; i < 3; i++) _balls[3][3].GetComponent<BallController>().AddPoint();
                break;
                */
            case 35:
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        _balls[i][j].GetComponent<BallController>().ChangeOwner(1);
                        _balls[4 + i][j].GetComponent<BallController>().ChangeOwner(2);
                    }
                }
                break;
            case 40:
                Vector3[] positions = new Vector3[64];
                List<int> pos = new List<int>();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        positions[i + j * 8] = _balls[i][j].GetComponent<Transform>().position;
                        int r = 0;
                        do r = _random.Next(0, 64); while (pos.Contains(r));
                        pos.Add(r);
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        _balls[i][j].GetComponent<Transform>().position = positions[pos[i + j * 8]];
                    }
                }
                break;
        }
        UpdateAllAnimations();

        _started = true;
    }

    public void UpdateAllAnimations()
    {
        for (int i = 0; i < BallsCountX; i++)
        {
            for (int j = 0; j < BallsCountY; j++)
            {
                _balls[i][j].GetComponent<BallController>().UpdateAnimation();
            }
        }
    }

    public void TeamFormation(TeamController[] _team) {
        var represent = new GameObject[9];
        int sup = 0;
        int cont1 = 1, cont2 = 1, cont3 = 1, cont4 = 1, cont5 = 1, cont6 = 1;
        for (int i = 0; i < _team.Length; i++)
        {
            var team = _team[i].GetPlayers();
                foreach (var player in team ){
                TeamMenu formation;
                represent[sup] = new GameObject();
                    switch (i) {
                        case 1: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (-1.7f * cont1), _team.Length -1 <= 2? ContadorDeTurno.transform.position.y : _team.Length - 1 <= 4 ? ContadorDeTurno.transform.position.y + 1.5f : ContadorDeTurno.transform.position.y + 2.5f, -2f);
                                cont1++;
                        break;
                        case 2: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (1.7f * cont2), _team.Length - 1 <= 2 ? ContadorDeTurno.transform.position.y : _team.Length -1 <= 4 ? ContadorDeTurno.transform.position.y + 1.5f : ContadorDeTurno.transform.position.y + 2.5f, -2f);
                                cont2++;
                        break;
                        case 3: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (-1.7f * cont3), _team.Length - 1 <= 4 ? ContadorDeTurno.transform.position.y -1.5f : ContadorDeTurno.transform.position.y, -2f);
                                cont3++;
                        break;
                        case 4: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (1.7f * cont4), _team.Length - 1 <= 4 ? ContadorDeTurno.transform.position.y -1.5f : ContadorDeTurno.transform.position.y, -2f);
                                cont4++;
                        break;
                        case 5: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (-1.7f * cont5), ContadorDeTurno.transform.position.y - 2.5f, -2f);
                                cont5++;
                        break;
                        case 6: represent[sup] = Instantiate(FormationTeamPrefab);
                                formation = represent[sup].GetComponent<TeamMenu>();
                                formation.StartValues(1, 3, player.PlayerColor);
                                represent[sup].GetComponent<Transform>().position = new Vector3(ContadorDeTurno.transform.position.x + (1.7f * cont6), ContadorDeTurno.transform.position.y - 2.5f, -2f);
                                cont6++;
                        break;
                    }
                sup++;
            }
        }

    }

    // Método que retorna o jogador que é dono da bolinha na posição indicada
    public PlayerController FindPlayer(int x, int y)
    {
        bool playerFound = false;
        int i;
        for (i = 0; !playerFound; i++)
        {
            playerFound = _playersControl[i].IsOwner((x - 1), y);
        }
        return _playersControl[i - 1];
    }
    // altera a cor do marcador de turno
    public void ChanceColorTurnPlayer(PlayerController CurrentPlayer)
    {
        ColorTurn.SpriteControl.color = CurrentPlayer.PlayerColor;
    }
    // Método que realiza a expansão da bolinha indicada
    public void ExpandBall(int x, int y)
    {
        // Adicionar ponto e tornar o dono da bolinha a esquerda, caso exista
        if (x != 0)
        {
            _balls[x - 1][y].GetComponent<BallController>().ChangeOwner(_currentPlayer);
            _balls[x - 1][y].GetComponent<BallController>().AddPoint();
        }
        // Adicionar ponto e tornar o dono da bolinha a baixo, caso exista
        if (y != 0)
        {
            _balls[x][y - 1].GetComponent<BallController>().ChangeOwner(_currentPlayer);
            _balls[x][y - 1].GetComponent<BallController>().AddPoint();
        }
        // Adicionar ponto e tornar o dono da bolinha a direita, caso exista
        if (x != _balls.Length - 1)
        {
            _balls[x + 1][y].GetComponent<BallController>().ChangeOwner(_currentPlayer);
            _balls[x + 1][y].GetComponent<BallController>().AddPoint();
        }
        // Adicionar ponto e tornar o dono da bolinha a cima, caso exista
        if (y != _balls[x].Length - 1)
        {
            _balls[x][y + 1].GetComponent<BallController>().ChangeOwner(_currentPlayer);
            _balls[x][y + 1].GetComponent<BallController>().AddPoint();
        }
        
    }

    // Método que passa o turno para o próximo jogador
    public void ChangeTurn()
    {
        WaitingInput = false;
        nextPlayer:
        VerifyGameOver();
        if (_gameOver)
        {
            UpdateAllAnimations();
            GameOver();
        }
        else
        {
			 
			if (ThisLevel == 30 && GetPlayer(1).Count() > GetPlayer(2).Count() && _random.Next(0, 5) == 0)
			{
				for (int i = 0; i < _balls.Length; i++)
				{
					for (int j = 0; j < _balls[i].Length; j++)
					{
						BallController ball = _balls[i][j].GetComponent<BallController>();
						if (ball.PlayerOwner.PlayerNumber == 1)
							ball.ChangeOwner(2);
						else if (ball.PlayerOwner.PlayerNumber == 2)
							ball.ChangeOwner(1);
					}
				}
			}
			if (!(ThisLevel == 25 && _currentPlayer == 2 && (repeat = !repeat)))
			{
				if (++_currentPlayer > _playersNumber)
					_currentPlayer = 1; // Caso seja o último jogador, o próximo é o primeiro
				if (GetCurrentPlayer().IsLoser()) // Caso o próximo jogador tenha perdido, passa para o próximo dele
					goto nextPlayer;
			}
        }
        UpdateAllAnimations();
    }

    // Método que verifica se a partida acabou
    // A partida acaba quando apena um time ainda não perdeu
    public bool VerifyGameOver()
    {
        int teamsInGame = 0;
        foreach (var team in _teamsControl)
        {
            if (!team.IsLoser())
                teamsInGame++;
            if (teamsInGame > 1)
                return _gameOver = false;
        }
        return _gameOver = true;
    }

    // Finaliza a partida
    public void GameOver()
    {
        int whoWin = 0;

        foreach (var player in _playersControl)
            if (!player.IsLoser())
            {
                whoWin = player.Team.TeamNumber;
                break;
            }
        //Debug.Log(string.Format("Time{0} ganhou", whoWin));
        if (whoWin == 1)
        {
            int progress = PlayerPrefs.GetInt("progress");
            if (ThisLevel > progress)
                PlayerPrefs.SetInt("progress", ThisLevel);
            SceneManager.LoadScene(/*ThisLevel == 20 ? "Lose" :*/ "Win");
        }
        else
        {
            SceneManager.LoadScene(/*ThisLevel == 20 ? "Win" :*/ "Lose");
        }
    }

    // Retorna o jogador atual
    public PlayerController GetCurrentPlayer()
    {
        return _playersControl[_currentPlayer];
    }

    // Retorna o jogador do número indicado
    public PlayerController GetPlayer(int number)
    {
        return _playersControl[number];
    }

    // Retorna a bolinha da posição indicada
    public BallController GetBall(int x, int y)
    {
        return _balls[x][y].GetComponent<BallController>();
    }

	// Método de erro
	public void setError(String error){
		this.Error.text = error;
	}

    // Método chamado a cada frame
    void Update()
    {
        if (!_started) return;
        ChanceColorTurnPlayer(GetCurrentPlayer());
        if (!WaitingInput) // Verifica se o jogo não está aguardando a ação de um jogador
        {
            _time += Time.deltaTime;
            if (_time >= 0.3) // Delay (0 - sem delay)
            {
                _time = 0;
                if (VerifyGameOver())
                    GameOver();
                GetCurrentPlayer().Play();
                
            }
        }
    }
}
