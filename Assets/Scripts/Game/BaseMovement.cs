using UnityEngine;
using System.Collections;

public abstract class BaseMovement : MonoBehaviour
{
    public LayerMask obstacleLayer;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    protected Animator animator;
    public int moveSpeed = 5;
    public float timeBetweenMoves = 0.5f;
    public bool isMoving;
    public bool isFacingRight;

    public int movesLeftThisTurn;

    protected virtual void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        isMoving = false;
	}
	
	

	
    protected bool Move(int x , int y, out RaycastHit2D hit)
    {
        isMoving = true;
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + new Vector2(x, y);
        box.enabled = false;
        hit = Physics2D.Linecast(startPos, endPos, obstacleLayer);
        box.enabled = true;

        if(hit.transform==null)
        {
            StartCoroutine(SmoothMove(endPos));
            return true;
        }
        else if(hit.transform!=null)
        {
            StartCoroutine(NegaliJudeti());
        }
        return false;
    }

    IEnumerator SmoothMove(Vector3 end)
    {
        float remainingDist = (transform.position - end).sqrMagnitude;

        while (remainingDist > float.Epsilon)
        {
            //do smooth movement
            Vector3 moveDirection = Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
            rb.MovePosition(moveDirection);
            remainingDist = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        isMoving = false;
    }

    IEnumerator NegaliJudeti()
    {
        yield return new WaitForSeconds(timeBetweenMoves);
        isMoving = false;
    }

    protected virtual bool AttemptMove<T>(int x, int y)
        where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(x, y, out hit);

        if(hit.transform==null)
        {
            return false;
        }

        T hitComponent = hit.transform.GetComponent<T>();

        if(!canMove && hitComponent!=null)
        {
            CantMove(hitComponent);
            return true;
        }
        else
        {
            return false;
        }

        if(!canMove)
        {
            return false; 
        }
    }

    protected abstract void CantMove<T>(T component)
        where T : Component;
}
