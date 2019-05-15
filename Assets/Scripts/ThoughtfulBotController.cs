// Classe que controla o bot pensativo, herda a classe base dos bots com inteligência
using UnityEngine;

public class ThoughtfulBotController : SearchBotBaseController
{

    // Bots usados
    private readonly NormalBotController NORMAL;
    private readonly AnnoyerBotController ANNOYER;
    private readonly SelfishBotController SELFISH;

    // Construtor da classe
    public ThoughtfulBotController(GameController game) : base(game)
    {
        NORMAL = new NormalBotController(game);
        ANNOYER = new AnnoyerBotController(game);
        SELFISH = new SelfishBotController(game);
    }

    // Implementação do método para encontrar o valor da bolinha
    public override int BallValue(Index index)
    {
        // Retorna a soma do valor da bolinha dos bots: normal, pentelho e egoista
        return NORMAL.BallValue(index) + ANNOYER.BallValue(index) + SELFISH.BallValue(index);
    }
}
