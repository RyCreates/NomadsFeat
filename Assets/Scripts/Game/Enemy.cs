using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

public class Enemy : BaseMovement
{
    public int XP;
    public int HP=10;
    public int attackStrength=10;
    public Transform target;
    public int howMuchTimesCanEnemyMove; // kad nesidubliuotu su playerio movementu kuris saugomas player prefabe

    public Canvas enemyCanv;
    public Slider enemySlid;
    public Text hitText;

    protected override void Start ()
    {
        // should be facing left at the start, couse player is at the enemies left
        isFacingRight = true;
        //FlipEnemyInXAxis();

        
        movesLeftThisTurn = howMuchTimesCanEnemyMove;
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
        GM.instance.enemiesList.Add(this);
        
        if(enemySlid!=null)
        {
            enemySlid.value = HP;
            enemySlid.direction = Slider.Direction.LeftToRight;
        }
        if (this.gameObject.tag == "Boss")
        {
            isFacingRight = false;
            FlipEnemyInXAxis();
            enemySlid.value = HP;
            enemySlid.direction = Slider.Direction.RightToLeft;
        }
    }
	
	public void EnemyMove()
    {
        int h = 0;
        int v = 0;

        if(Mathf.Abs(transform.position.x - target.position.x) < 0.6f) // at the same column
        {
            v = transform.position.y > target.position.y ? -1 : 1;
        }
        else
        {
            h = transform.position.x > target.position.x ? -1 : 1;

            if (h == 1 && !isFacingRight)
            {
                // ziuri i desine ir movina i desine 
                FlipEnemyInXAxis();
            }
            else if (h == -1 && isFacingRight)
            {
                // ziuri i desine ir movina i kaire 
                FlipEnemyInXAxis();
            }
        }
         
        if((h!=0 || v!=0) && !GM.instance.playersTurn && !isMoving && movesLeftThisTurn>0)
        {
            AttemptMove<Player>(h, v); 
            movesLeftThisTurn--;
            if(movesLeftThisTurn<=0)
            {
                GM.instance.howManyEnemiesEndedTurn++;
            }
            if (base.AttemptMove<Player>(h, v))
            {
                if(this.gameObject.tag=="Enemy")
                {
                    animator.SetTrigger("EnemyAttack");
                }
                else if(this.gameObject.tag=="Boss")
                {
                    int a = Random.Range(0, 3);
                    if(a==0)
                    {
                        animator.SetTrigger("EnemyAttack1");
                    }
                    else
                    {
                        animator.SetTrigger("EnemyAttack2");
                    }
                }

                
            }
            else if (!base.AttemptMove<Player>(h, v))
            {
                animator.SetTrigger("EnemyMove");
            }
        }
    }

    protected override void CantMove<T>(T component)
    {
        // attack player
        Player hitPlayer = component as Player;
        hitPlayer.TakeDamage(attackStrength);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if(HP<=0)
        {
            Die();
            GM.instance.UpdatePlayerXP(XP);
            GM.instance.GMUpdateXPBar();
        }
        StartCoroutine(UpdateEnemySlider()); 
    }

    public void Die()
    {
        GM.instance.enemiesList.Remove(this.gameObject.GetComponent<Enemy>());
        StartCoroutine(DestroyEnemyAfterSomeTime());
    }

    IEnumerator DestroyEnemyAfterSomeTime()
    {
        if (this.gameObject.tag == "Enemy")
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
        else if(this.gameObject.tag=="Boss")
        {
            GM.instance.KillBoss();
            yield return new WaitForSeconds(0.5f);
            animator.SetTrigger("EnemyDie");
            yield return new WaitForSeconds(0.3f);
            Destroy(this.gameObject);
        }
    }

    public void FlipEnemyInXAxis()
    {
        if (isFacingRight)
        {
            isFacingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
            enemySlid.direction = Slider.Direction.RightToLeft;
        }
        else if(!isFacingRight)
        {
            isFacingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            enemySlid.direction = Slider.Direction.LeftToRight;
        }
        if(this.gameObject.tag=="Boss" && isFacingRight)
        {
            enemySlid.direction = Slider.Direction.RightToLeft;
        }
        else if (this.gameObject.tag == "Boss" && !isFacingRight)
        {
            enemySlid.direction = Slider.Direction.LeftToRight;
        }
    }

    void EnemySliderMethod()
    {
        enemySlid.maxValue = HP;
        enemySlid.minValue = 0;
        enemySlid.value = HP;
    }

    IEnumerator UpdateEnemySlider()
    {
        yield return new WaitForSeconds(0.2f);
        enemySlid.value = HP;
    }

}
