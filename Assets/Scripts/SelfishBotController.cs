// Classe que controla o bot egoísta, herda o bot normal
public class SelfishBotController : NormalBotController {

    // Construtor da classe
    public SelfishBotController(GameController game) : base(game) { }

    // Sobreescreve o método para obter o valor da bolinha
    public override int BallValue(Index index)
    {
        // Utiliza o método do bot normal para obter o valor da bolinha, porém usando o método de comparar os vizinhos desta classe
        int value = base.BallValue(index);

        var ball = _gameControl.GetBall(index.x, index.y);

        // Verifica se a bolinha já pertence ao jogador
        if (ball.PlayerOwner == _gameControl.GetCurrentPlayer())
            // Adiciona a prioridade da bolinha 2000 vezes 4 menos a quantidade de pontos para expandir
            // 1 ponto para expandir = 6000
            // 2 pontos para expandir = 4000
            // 3 pontos para expandir = 2000
            // 4 pontos para expandir = 0
            value += (4-ball.PointsToExpand())*2000;

        // Retorna o valor
        return value;
    }

    // Sobreescreve o método que retorna a mudança no valor da bolinha de acordo com o vizinho
    protected override int CompareNeighbor(BallController ball, BallController neighbor)
    {
        int value = 0;

        // Verifica se o vizinho pertence ao mesmo time, caso seja adiciona 1000 pontos de prioridade
        if (_gameControl.GetCurrentPlayer().Team == neighbor.PlayerOwner.Team)
            value += 1000;
        // Verifica se o vizinho pertence ao jogador de outro time
        else if (neighbor.PlayerOwner != _gameControl.GetPlayer(0) &&
                 _gameControl.GetCurrentPlayer().Team != neighbor.PlayerOwner.Team)
            // Caso esta bolinha estiver mais próxima de explodir do que o vizinho, adiciona 2000 de prioridade, caso contrário reduz 2000
            value += ball.PointsToExpand() <= neighbor.PointsToExpand() ? 2000 : -2000;

        // Verifica se o próximo ponto desta bolinha vai explodir ela e o vizinho, caso seja adiciona 5000
        if (ball.PointsToExpand() == 1 && neighbor.PointsToExpand() == 1)
            value += 5000;

        // Retorna o valor
        return value;
    }
}
