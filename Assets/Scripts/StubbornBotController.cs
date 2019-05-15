// Classe que controla o bot teimoso, herda o bot burro
public class StubbornBotController : DumbBotController {

    // Bolinha alvo do bot
    public BallController Target { get; set; }

    // Construtor da classe
    public StubbornBotController(GameController game) : base(game) { }

    // Implementação do método para selecionar a bolinha a ser clicada
    public override BallController SelectBall()
    {
        // Verifica se não foi marcado um alvo ainda, ou o alvo marcado não pode ser clicado por este jogador
        // É escolhido outro alvo, utilizando o método de escolha do bot burro
        // Caso contrário, mantem o alvo atual
        if (Target == null || !Target.CanClick())
            Target = base.SelectBall();
        // Retorna o alvo
        return Target;
    }
}
