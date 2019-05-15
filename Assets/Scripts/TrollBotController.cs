// Classe que controla o bot troll, herda o bot pentelho
public class TrollBotController : AnnoyerBotController {

    // Construtor da classe
    public TrollBotController(GameController game) : base(game) { }

    // Sobreescreve o método para obter o valor da bolinha
    public override int BallValue(Index index)
    {
        // Utiliza o método do bot normal para obter o valor da bolinha, porém usando o método de comparar os vizinhos desta classe
        int value = base.BallValue(index);

        var ball = _gameControl.GetBall(index.x, index.y);

        // Verifica se no próximo clique a bolinha vai expandir, caso seja reduz 1000000 pontos de prioridade
        if (ball.PointsToExpand() == 1)
            value -= 1000000;

        // Retorna o valor
        return value;
    }

    // Sobreescreve o método que retorna a mudança no valor da bolinha de acordo com o vizinho
    protected override int CompareNeighbor(BallController ball, BallController neighbor)
    {
        // Utiliza o método do bot pentelho para obter a mudança no valor da bolinha em relação ao vizinho e retorna o obosto deste valor
        return -base.CompareNeighbor(ball, neighbor);
    }
}