using UnityEngine;

public class Figure : MonoBehaviour
{
    public FigureType figureType;

    public IMoveBehaviour moveBehaviour;

    public void ApplyMove()
    {
        moveBehaviour.CanReach();
    }

    void SetMoveBehaviour(IMoveBehaviour moveType)
    {
        moveBehaviour = moveType;
    }

    public void AssignTypeBehaviour(FigureType type)
    {
        switch(type)
        {
            case FigureType.Pawn:
                SetMoveBehaviour(new PawnMove());
                break;
            case FigureType.Rook:
                SetMoveBehaviour(new RookMove());
                break;
            case FigureType.Knight:
                SetMoveBehaviour(new KnightMove());
                break;
            case FigureType.Bishop:
                SetMoveBehaviour(new BishopMove());
                break;
            case FigureType.Queen:
                SetMoveBehaviour(new QueenMove());
                break;
            case FigureType.King:
                SetMoveBehaviour(new KingMove());
                break;
        }
        figureType = type;
    }

    public void Die()
    {
        if(transform.GetComponent<MeshRenderer>().material.color == Color.black)
        {
            BoardManager.blackFigures.Remove(this);
        }
        else
        {
            BoardManager.whiteFigures.Remove(this);
        }
        BoardManager.board[(int)transform.position.x, (int)transform.position.z].figure = null;
        if(DriverV2.AnimationON)
        {
            Destroy(gameObject, 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
