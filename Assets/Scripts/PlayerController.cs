using UnityEngine;

// Classe que controla os jogadores
public class PlayerController
{

    // Número do jogador
    public int PlayerNumber { get; private set; }
    // Cor do jogador
    public Color PlayerColor { get; private set; }
    // Time que o jogador pertence
    public TeamController Team { get; internal set; }

    // Jogo ao qual pertence
    private GameController _gameControl;

    // Bot que controla o jogador, caso seja humano o valor é null
    private BotBaseController _botControl;

    // Construtor da classe
    public PlayerController(int number, GameController game, BotBaseController bot, Color color, TeamController team)
    {
        PlayerNumber = number;
        _gameControl = game;
        _botControl = bot;
        PlayerColor = color;
        Team = team;
        team.AddPlayer(this);
    }

    // Verifica se este jogador é dono da bolinha na posição indicada
    public bool IsOwner(int x, int y)
    {
        return _gameControl.GetBall(x, y).PlayerOwner == this;
    }

    // Conta a quantidade de bolinhas que este jogador possui
    public int Count()
    {
        int count = 0;
        for (int i = 0; i < _gameControl.BallsCountX; i++)
        {
            for (int j = 0; j < _gameControl.BallsCountY; j++)
            {
                if (_gameControl.GetBall(i, j).PlayerOwner == this) count++;
            }
        }
        return count;
    }

    // Realiza a jogada
    public void Play()
    {
        // Caso não seja a vez deste jogador retorna um erro
        if (_gameControl.GetCurrentPlayer() != this)
            throw new System.Exception();
        // Caso o jogador seja humano, o jogo espera a ação dele
        if (_botControl == null)
            _gameControl.WaitingInput = true;
        // Caso o jogador seja bot, é executada a sua jogada
        else
            _botControl.Play();
    }

    // Verifica se o jogador perdeu
    // O jogador perde quando não lhe é permitido clicar em nenhuma bolinha do jogo; quando ele não possuir nenhuma bolinha e também não tiver nenhuma sem dono
    public bool IsLoser()
    {
        return PlayerNumber == 0 || Count() == 0 && ( (_gameControl.ThisLevel == 15 && PlayerNumber == 1) || _gameControl.ThisLevel == 10 || _gameControl.GetPlayer(0).Count() == 0) /*|| (_gameControl.ThisLevel == 20 && PlayerNumber == 2 && Count() < _gameControl.GetPlayer(1).Count() - 5)*/ || (_gameControl.ThisLevel == 35 && PlayerNumber == 1 && Count() < _gameControl.GetPlayer(2).Count());
    }
}
