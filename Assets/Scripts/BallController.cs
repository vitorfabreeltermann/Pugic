using UnityEngine;
using System;

// Classe responsável por controlar as bolinhas
public class BallController : MonoBehaviour {
    
    // Sprite da bolinha
    public SpriteRenderer SpriteControl;

    // Atual dono da bolinha
    public PlayerController PlayerOwner { get; private set; } // 0 -> none

    // Animador da bolinha
    public Animator animationControl;

    // Quantidade atual de pontos
    public int Points { get; private set; }

    // Número de vizinhos
    public int NeighborNumber { get; private set; }

    // Jogo ao qual pertence
    private GameController gameControl;

    // Posição no eixo X
    public int PosX { get; private set; }
    // Posição no eixo Y
    public int PosY { get; private set; }

    // Variável para garantir que o método StartValues seja chamado apenas uma vez
    private bool _valuesStarted = false;

    // Define valores iniciais
    // Deve ser chamado apenas uma vez
    public void StartValues(int neighbors, int x, int y, GameController game, PlayerController inicialOwner)
    {
        if (!_valuesStarted)
        {
            Points = 0;
            NeighborNumber = neighbors;
            PosX = x;
            PosY = y;
            gameControl = game;
            PlayerOwner = inicialOwner;
            _valuesStarted = true;
        }
    }

    // Evento de clique de um jogador (não bot)
    void OnMouseDown()
    {
		gameControl.setError("");
        if (gameControl.WaitingInput)
            try {
                ProcessClick();
            }catch(CannotClickException e)
            {
                //Debug.Log(e.ToString());
				gameControl.setError(e.ToString());
            }
    }

    // Processa a ação de clique (jogador humano E bot)
    public void ProcessClick()
    {
        // Verifica se pode clicar, cano não possa causa uma exceção
        if (!CanClick())
            throw new CannotClickException();
        // Se a bolinha não pertence a ninguém, passa a ser do jogador que clicou
        if (PlayerOwner.PlayerNumber == 0)
            PlayerOwner = gameControl.GetCurrentPlayer();
        // Adiciona um ponto
        AddPoint();
        // Passa o turno
        gameControl.ChangeTurn();
    }

    // Verifica se o jogador atual tem permição para clicar nesta bolinha
    public bool CanClick()
    {
        return PlayerOwner == gameControl.GetCurrentPlayer() || (gameControl.ThisLevel != 10 && PlayerOwner.PlayerNumber == 0);
    }

    // Adiciona um ponto a bolinha
    public void AddPoint()
    {
        Points++;
        // Verifica se ultrapassou o limite de pontos, caso tenha feito expande a bolinha
        if (ExceedLimit())
        {
            CleanPoints();
            if(!gameControl.VerifyGameOver()) // Faz verificação de fim de jogo para evitar loop infinito
                gameControl.ExpandBall(PosX, PosY);
        }
        // Atualiza a animação da bolinha
        //UpdateAnimation();
    }

    // Zera a quantidade de pontos da bolinha
    public void CleanPoints()
    {
        Points = 0;
    }

    // Verifica se a bolinha ultrapassou o limite de pontos (se prezisa expandir)
    public bool ExceedLimit()
    {
        return Points >= NeighborNumber;
    }

    // Muda o dono da bolinha
    public void ChangeOwner(int owner)
    {
        PlayerOwner = gameControl.GetPlayer(owner);

        // Atualiza a animação
        //UpdateAnimation();
    }

    // Retorna a quantidade de pontos necessária para expandir
    public int PointsToExpand()
    {
        return NeighborNumber - Points;
    }

    // Atualiza a animação
    public void UpdateAnimation()
    {
        // Muda a animação de acordo com a quantidade de pontos
        animationControl.SetInteger("Points", Points);

        // Muda a cor da bolinha
        SpriteControl.color = PlayerOwner.PlayerColor;
    }

    // Exceção de clique inválido, ocorre quando um jogador clica em uma bolinha que não lhe é permitida
    public class CannotClickException : Exception
    {
        public override string ToString()
        {
            return "Invalid move!";
        }
    }
}
