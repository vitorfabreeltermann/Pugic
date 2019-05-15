using System;

// Classe abastrata base para todos os bots
public abstract class BotBaseController {

    // Classe interna para guardar o índice das bolinhas
    public class Index
    {
        public int x, y;
    }

    // Jogo ao qual pertence
    protected GameController _gameControl;

    // Gerador de valores aleatórios
    protected static Random _random = new Random();

    // Construtor da classe
    public BotBaseController(GameController game)
    {
        _gameControl = game;
    }

    // Método que executa a ação do bot
    // Seleciona uma bolinha e processa o clique dela
    public void Play()
    {
        SelectBall().ProcessClick();
    }

    // Método abstrato que seleciona qual bolinha vai ser clicada
    public abstract BallController SelectBall();
}
