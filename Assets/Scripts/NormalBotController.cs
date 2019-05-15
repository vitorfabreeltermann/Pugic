// Classe que controla o bot normal, herda o a base de bot com inteligência
public class NormalBotController : SearchBotBaseController
{
    // Construtor da classe
    public NormalBotController(GameController game) : base(game) { }

    // Implementação do método para encontrar o valor da bolinha
    public override int BallValue(Index index)
    {
        // O valor inicial é um número aleatório entre -500 e 500
        // Este valor é realtivamente baixo e serve apenas como critério de desempate quando duas ou mais bolinhas possuirem o mesmo valor
        int value = _random.Next(-500, 500);

        var ball = _gameControl.GetBall(index.x, index.y);
        // Verifica as bolinhas vizinhas, caso existam, e pontua de acordo com o estado delas
        // Esquerda
        if (index.x != 0)
        {
            var neighbor = _gameControl.GetBall(index.x - 1, index.y);

            value += CompareNeighbor(ball, neighbor);
        }
        // Baixo
        if (index.y != 0)
        {
            var neighbor = _gameControl.GetBall(index.x, index.y - 1);

            value += CompareNeighbor(ball, neighbor);
        }
        // Direita
        if (index.x != _gameControl.BallsCountX - 1)
        {
            var neighbor = _gameControl.GetBall(index.x + 1, index.y);

            value += CompareNeighbor(ball, neighbor);
        }
        // Cima
        if (index.y != _gameControl.BallsCountY - 1)
        {
            var neighbor = _gameControl.GetBall(index.x, index.y + 1);

            value += CompareNeighbor(ball, neighbor);
        }
        // Restorna o valor da bolinha
        return value;
    }

    // Método virtual que retorna a mudança no valor da bolinha de acordo com o vizinho
    protected virtual int CompareNeighbor(BallController ball, BallController neighbor)
    {
        int value = 0;
        // Verifica se o vizinho também pertencer a ele
        if (_gameControl.GetCurrentPlayer() == neighbor.PlayerOwner)
        {
            // Caso esta bolinha estiver mais próxima de explodir do que o vizinho, adiciona 1000 de prioridade, caso contrário reduz 1000
            value += ball.PointsToExpand() <= neighbor.PointsToExpand() ? 1000 : -1000;
        }
        // Verifica se o vizinho pertence a um jogador de outro time, que não seja o neutro (time 0)
        else if (neighbor.PlayerOwner != _gameControl.GetPlayer(0) &&
                 _gameControl.GetCurrentPlayer().Team != neighbor.PlayerOwner.Team)
        {
            // Caso esta bolinha estiver mais próxima de explodir do que o vizinho, adiciona 5000 de prioridade, caso contrário reduz 5000
            value += ball.PointsToExpand() <= neighbor.PointsToExpand() ? 5000 : -5000;
        }
        // Retorna o valor
        return value;
    }
}

