using System;
// Classe que controla o bot misterioso, herda a classe base dos bots
public class MysteriousBotController : BotBaseController
{
    // Bots usados
    private readonly DumbBotController DUMB;
    private readonly NormalBotController NORMAL;
    private readonly AnnoyerBotController ANNOYER;
    private readonly SelfishBotController SELFISH;
    private readonly StubbornBotController STUBBORN;
    private readonly TrollBotController TROLL;
    private readonly ThoughtfulBotController THOUGHTFUL;

    // Bot atual
    private BotBaseController _currentBot;

    // Contador de rounds para troca de bot
    private int _roundCount = 0;
    private const int NUMBER_OF_ROUNDS = 3;

    // Construtor da classe
    public MysteriousBotController(GameController game) : base(game)
    {
        DUMB = new DumbBotController(game);
        NORMAL = new NormalBotController(game);
        ANNOYER = new AnnoyerBotController(game);
        SELFISH = new SelfishBotController(game);
        STUBBORN = new StubbornBotController(game);
        TROLL = new TrollBotController(game);
        THOUGHTFUL = new ThoughtfulBotController(game);
        SelectBot();
    }

    // Implementação do método para selecionar a bolinha a ser clicada
    public override BallController SelectBall()
    {
        // Verifica se já é para trocar de bot
        if(++_roundCount > NUMBER_OF_ROUNDS)
        {
            // Troca de bot
            SelectBot();
            _roundCount = 0;
        }
        // Retorna a bolinha de acordo com o bot atual
        return STUBBORN.Target = _currentBot.SelectBall();
    }

    // Método que seleciona um dos bots aleatoriamente
    private BotBaseController SelectBot()
    {
        int r = _random.Next(0, 7);
        switch (r)
        {
            case 0: return _currentBot = DUMB;
            case 1: return _currentBot = NORMAL;
            case 2: return _currentBot = ANNOYER;
            case 3: return _currentBot = SELFISH;
            case 4: return _currentBot = STUBBORN;
            case 5: return _currentBot = TROLL;
            case 6: return _currentBot = THOUGHTFUL;
            default: throw new Exception();
        }
    }
}
