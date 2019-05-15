// Classe que controla o bot burro, herda a classe base dos bots
using System;

public class DumbBotController : SearchBotBaseController
{
    // Construtor da classe
    public DumbBotController(GameController game) : base(game) { }

    // Implementação do método para encontrar o valor da bolinha
    public override int BallValue(Index index)
    {
        // O valor inicial é um número aleatório entre -500 e 500
        // Este valor é realtivamente baixo e serve apenas como critério de desempate quando duas ou mais bolinhas possuirem o mesmo valor
        int value = _random.Next(-500, 500);

        // Restorna o valor da bolinha
        return value;
    }
}
