// Classe que controla o bot pentelho, herda o bot normal
public class AnnoyerBotController : NormalBotController
{
    // Construtor da classe
    public AnnoyerBotController(GameController game) : base(game) { }

    // Sobreescreve o método que retorna a mudança no valor da bolinha de acordo com o vizinho
    protected override int CompareNeighbor(BallController ball, BallController neighbor)
    {
        // Utiliza o método do bot normal para obter a mudanla no valor da bolinha de acordo com o vizinho
        int value = base.CompareNeighbor(ball, neighbor);

        // Verifica as bolinhas vizinhas do vizinho, caso existam, e pontua de acordo com o estado delas
        // Esquerda do vizinho
        if (neighbor.PosX != 0)
        {
            var neighborNeighbor = _gameControl.GetBall(neighbor.PosX - 1, neighbor.PosY);

            value += CompareNeighborNeighbor(ball, neighborNeighbor);
        }
        // Baixo do vizinho
        if (neighbor.PosY != 0)
        {
            var neighborNeighbor = _gameControl.GetBall(neighbor.PosX, neighbor.PosY - 1);

            value += CompareNeighborNeighbor(ball, neighborNeighbor);
        }
        // Direita do vizinho
        if (neighbor.PosX != _gameControl.BallsCountX - 1)
        {
            var neighborNeighbor = _gameControl.GetBall(neighbor.PosX + 1, neighbor.PosY);

            value += CompareNeighborNeighbor(ball, neighborNeighbor);
        }
        // Cima do vizinho
        if (neighbor.PosY != _gameControl.BallsCountY - 1)
        {
            var neighborNeighbor = _gameControl.GetBall(neighbor.PosX, neighbor.PosY + 1);

            value += CompareNeighborNeighbor(ball, neighborNeighbor);
        }

        // Retorna o valor
        return value;
    }

    // Método virtual que retorna a mudança no valor da bolinha de acordo com o vizinho do vizinho
    private int CompareNeighborNeighbor(BallController ball, BallController neighborNeighbor)
    {
        int value = 0;

        // Verifica se o vizinho do vizinho pertencer a alguém que não seja do mesmo time
        if (neighborNeighbor.PlayerOwner != _gameControl.GetPlayer(0) &&
            _gameControl.GetCurrentPlayer().Team != neighborNeighbor.PlayerOwner.Team)
        {
            // Adiciona a prioridade da bolinha 1000 vezes 4 menos a quantidade de pontos para expandir
            // 1 ponto para expandir = 3000
            // 2 pontos para expandir = 2000
            // 3 pontos para expandir = 1000
            // 4 pontos para expandir = 0
            value += (4-neighborNeighbor.PointsToExpand())*1000;
        }

        // Retorna o valor
        return value;
    }
}
