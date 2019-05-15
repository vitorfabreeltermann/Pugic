using System.Collections.Generic;

// Classe que controla os times
public class TeamController {

    // Membros do time
    // O índice do jogador no time é o número do jogador
    private Dictionary<int, PlayerController> _members = new Dictionary<int, PlayerController>();

    // Número do time
    public int TeamNumber { get; private set; }

    // Construtor da classe
    public TeamController(int number)
    {
        TeamNumber = number;
    }

    // Adiciona um membro ao time
    // O índice do jogador no time é o número do jogador
    public void AddPlayer(PlayerController player)
    {
        _members.Add(player.PlayerNumber, player);
        player.Team = this;
    }

    // Retorna o jogador do time
    // O índice do jogador no time é o número do jogador
    public PlayerController GetPlayer(int playerNumber)
    {
        return _members[playerNumber];
    }

    // Retorna todos os membros do time
    public Dictionary<int, PlayerController>.ValueCollection GetPlayers()
    {
        return _members.Values;
    }

    // Verifica se o jogador pertence ao time
    public bool IsBelonging(PlayerController player)
    {
        return _members.ContainsValue(player);
    }

    // Verifica se o jogador que possui este número pertence ao time
    public bool IsBelonging(int playerNumber)
    {
        return _members.ContainsKey(playerNumber);
    }

    // Remove o jogador que possui este número do time
    public void RemovePlayer(int playerNumber)
    {
        _members[playerNumber].Team = null;
        _members.Remove(playerNumber);
    }

    // Remove o jogador do time
    public void RemovePlayer(PlayerController player)
    {
        player.Team = null;
        _members.Remove(player.PlayerNumber);
    }

    // Conta a quantidade de membros do time
    public int Count()
    {
        return _members.Count;
    }

    // Verifica se o time perdeu
    // O time perde quando todos os jogadores do time perderem
    public bool IsLoser()
    {
        foreach (var player in GetPlayers())
            if (!player.IsLoser())
                return false;

        return true;
    }
}
