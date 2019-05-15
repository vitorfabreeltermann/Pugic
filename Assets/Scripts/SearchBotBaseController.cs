using System;

// Classe abastrata base para todos os bots que utilizam o sistema de buscar bolinhas por pontos
public abstract class SearchBotBaseController : BotBaseController {

    // Construtor
    public SearchBotBaseController(GameController game) : base(game) { }

    // Método para selecionar a bolinha
    public override BallController SelectBall()
    {
        var index = new Index() { x = 0, y = 0 };

        int value = int.MinValue;
        Index selected = new Index();

        // Percorre todas as bolinhas do mapa
        for (int i = 0; i < _gameControl.BallsCountX; i++)
        {
            index.x = i;
            for (int j = 0; j < _gameControl.BallsCountY; j++)
            {
                index.y = j;
                // Verifica se pode clicar nesta bolinha
                if (_gameControl.GetBall(i, j).CanClick())
                {
                    // Encontra o valor desta bolinha
                    int newValue = BallValue(index);
                    // Verifica se o valor desta bolinha é maior que o maior valor já encontrado até então
                    // Caso seja, este passa a ser o melhor valor encontrado
                    if (value < newValue)
                    {
                        value = newValue;
                        selected.x = i;
                        selected.y = j;
                    }
                }
            }
        }

        // Retorna a bolinha de maior valor encontrada
        return _gameControl.GetBall(selected.x, selected.y);
    }

    // Método abstrato que encontra o valor da bolinha
    public abstract int BallValue(Index index);
}
