using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
//using System;

public class Player : BaseMovement
{
    public bool stopHoldingButton;
    public int restartLevelDelay = 1;

    public int howMuchTimesCanMove;
    

    private Vector2 touchOrigin = -Vector2.one;

    protected override void Start()
    {
        isFacingRight = true;
        GM.instance.playerMovesTotal = PlayerStats.playerStats_Moves;
        GM.instance.playerMovesLeft = PlayerStats.playerStats_Moves;
        movesLeftThisTurn = GM.instance.playerMovesTotal;
        base.Start();
        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
        stopHoldingButton = false;
        TikrinamAnimatorSpriteRendererioBool();
    }
	
	

	void Update ()
    {
        int v = 0;
        int h = 0;
        if(!EventSystem.current.IsPointerOverGameObject())
        {

        
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR


        h = (int)Input.GetAxisRaw("Horizontal");
        v = (int)Input.GetAxisRaw("Vertical");

            if(h>0)
            {
                isFacingRight = true;
            }
            else if(h<0)
            {
                isFacingRight = false;
            }
        if(h!=0)
        {
            v = 0;
        }



#else

        if(Input.touchCount>0)
        {
            

            Touch myTouch = Input.touches[0]; // we grab first touch and ignore all other touches
        
        
        
            

            if(myTouch.phase==TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
                GM.instance.TouchCanvasIsOpen = true;
                GM.instance.TouchImage.transform.position = touchOrigin;
            }
            else if(myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) 
            {
                GM.instance.TouchCanvasIsOpen = false;
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;

                    if(Mathf.Abs(x)>0.2f || Mathf.Abs(y)>0.2f)
                    {

                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            h = x > 0 ? 1 : -1;
                            isFacingRight = x > 0 ? true : false;
                        }
                        else
                        {
                            v = y > 0 ? 1 : -1;
                        }
                    }
            }
        }
        else if(Input.touchCount<=0)
        {
        GM.instance.TouchCanvasIsOpen = false;
        }
#endif
        }


        TikrinamAnimatorSpriteRendererioBool();

        if ((h!=0 || v!=0) && !isMoving && GM.instance.playersTurn && !stopHoldingButton)
        {
            stopHoldingButton = true;
            AttemptMove<Enemy>(h, v);

            if(AttemptMove<Enemy>(h,v)) // smugiuoja
            {
                // atimam stamina su kiekvienu bandymu eiti !!!!!!
                if (GM.instance.playerCurrentStamina > 0)
                {
                    GM.instance.movesUsedInThisLevelForCountingStars++; 
                    GM.instance.playerCurrentStamina--;
                    GM.instance.UpdatePlayerStamina(0);
                    GM.instance.GMUpdateStaminaBar();
                }
                else if (GM.instance.playerCurrentStamina <= 0)
                {
                    GM.instance.movesUsedInThisLevelForCountingStars++; 
                    GM.instance.playerCurrentHP--;
                    GM.instance.UpdatePlayerHP(0);
                    GM.instance.GMUpdateHPBar();
                    if (GM.instance.playerCurrentHP <= 0)
                    {
                        GM.instance.playerCurrentHP = 0; 
                        GM.instance.LoseThisMap();
                    }
                }

                // smugiuoja - butinai turi tureti sworda
                if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
                {
                    animator.SetTrigger("AttackSwordRight");
                }
                else if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
                {
                    animator.SetTrigger("AttackSwordLeft");
                }
                else if(GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
                {
                    animator.SetTrigger("AttackSwordAndBootsRight");
                }
                else if (GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
                {
                    animator.SetTrigger("AttackSwordAndBootsLeft");
                }
            }
            else // juda
            {

                // atimam stamina su kiekvienu bandymu eiti !!!!!!
                if (GM.instance.playerCurrentStamina > 0)
                {
                    GM.instance.movesUsedInThisLevelForCountingStars++;
                    GM.instance.playerCurrentStamina--;
                    GM.instance.UpdatePlayerStamina(0);
                    GM.instance.GMUpdateStaminaBar();
                }
                else if (GM.instance.playerCurrentStamina <= 0)
                {
                    GM.instance.movesUsedInThisLevelForCountingStars++;
                    GM.instance.playerCurrentHP--;
                    GM.instance.UpdatePlayerHP(0);
                    GM.instance.GMUpdateHPBar();
                    if (GM.instance.playerCurrentHP <= 0)
                    {
                        GM.instance.playerCurrentHP = 0; 
                        GM.instance.LoseThisMap();
                    }
                }

                // jeigu movina 
                if (!GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && isFacingRight) // cia kazkodel sumaisyta editoriuje, ne klaida
                {
                    animator.SetTrigger("MoveEmptyRight");
                }
                else if (!GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && !isFacingRight) // cia kazkodel sumaisyta editoriuje, ne klaida
                {
                    animator.SetTrigger("MoveEmptyLeft");
                }
                else if (GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && isFacingRight)
                {
                    animator.SetTrigger("MoveBootsRight");
                }
                else if (GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && !isFacingRight)
                {
                    animator.SetTrigger("MoveBootsLeft");
                }
                else if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
                {
                    animator.SetTrigger("MoveSwordRight");
                }
                else if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
                {
                    animator.SetTrigger("MoveSwordLeft");
                }
                else if (GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
                {
                    animator.SetTrigger("MoveSwordAndBootsRight");
                }
                else if (GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
                {
                    animator.SetTrigger("MoveSwordAndBootsLeft");
                }
            }

            movesLeftThisTurn--;
            if (movesLeftThisTurn > 0)
            {
                GM.instance.playerMovesLeft = movesLeftThisTurn;
                GM.instance.UpdateMovesLeft(movesLeftThisTurn);
            }

            if (GM.instance.enemiesList.Count <= 0)
            {
                GM.instance.playersTurn = true;
                if (movesLeftThisTurn == 0)
                {
                    movesLeftThisTurn = GM.instance.playerMovesTotal;
                    GM.instance.UpdateMovesLeft(movesLeftThisTurn);
                }
            }

            else if (movesLeftThisTurn <= 0)
            {
                GM.instance.playerMovesLeft = movesLeftThisTurn;
                GM.instance.UpdateMovesLeft(movesLeftThisTurn);
                StartCoroutine(SwitchTurnDelay());
            }
        }
        if(h==0 && v == 0)
        {
            stopHoldingButton = false;
        }
    }

    IEnumerator SwitchTurnDelay()
    {
        yield return new WaitForSeconds(0.01f);
        GM.instance.playersTurn = false;
        movesLeftThisTurn = GM.instance.playerMovesTotal;

    }

    
    void TikrinamAnimatorSpriteRendererioBool()
    {
        
        //tikrinam player idle sprite rendereri
        if (!GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", true);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (!GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && !isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", true);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", true);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
        }
        else if (GM.instance.doesHaveBoots && !GM.instance.doesHaveSword && !isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", true);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", true);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (!GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", true);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (GM.instance.doesHaveBoots && GM.instance.doesHaveSword && isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", true);
            animator.SetBool("IdleSwordAndBootsLeft", false);
        }
        else if (GM.instance.doesHaveBoots && GM.instance.doesHaveSword && !isFacingRight)
        {
            animator.SetBool("IdleEmptyRight", false);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleBootsRight", false);
            animator.SetBool("IdleBootsLeft", false);
            animator.SetBool("IdleSwordRight", false);
            animator.SetBool("IdleSwordLeft", false);
            animator.SetBool("IdleSwordAndBootsRight", false);
            animator.SetBool("IdleSwordAndBootsLeft", true);
        }

    }

    protected override bool AttemptMove<T>(int x, int y)
    {        
        base.AttemptMove<T>(x, y);
        RaycastHit2D hit;
        if(base.AttemptMove<T>(x,y))
        {
            return true;
        }
        else
        {
            return false;
        }
        //if (Move(x, y, out hit))
        {
            // vel kreipiasi i move funkcija
        }

        // GM.instance.playersTurn = false; // cia blogai !!!!!!!!
    }

    protected override void CantMove<T>(T component)
    {
        // attack enemy
            Enemy hitEnemy = component as Enemy;
            hitEnemy.TakeDamage(GM.instance.playerStrength);
            
    }

    public void TakeDamage(int dmg)
    {
        GM.instance.playerCurrentHP -= dmg;        
        GM.instance.UpdatePlayerHP(0);
        GM.instance.GMUpdateHPBar();
        if (GM.instance.playerCurrentHP <= 0)
        {
            GM.instance.playerCurrentHP = 0;
            GM.instance.LoseThisMap();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Exit")
        {
            GM.instance.enemiesList.Clear();
            GM.instance.chamber++;
            if(GM.instance.chamber > GM.instance.chamberToWin)
            {
                // if win this map - upgrade 3stars and unlock next level 


                GM.instance.WinThisMap();
            }
            GM.instance.UpdateChamber(0);
            Destroy(other.gameObject);
            Invoke("Restart", restartLevelDelay);
        }
        else if(other.tag=="Food")
        {
            Destroy(other.gameObject);
            GM.instance.playerCurrentHP += 10;
            if(GM.instance.playerCurrentHP>GM.instance.playerTotalHP)
            {
                GM.instance.playerCurrentHP = GM.instance.playerTotalHP;
            }
            GM.instance.UpdatePlayerHP(0);
            GM.instance.GMUpdateHPBar();
        }
        else if (other.tag == "Stamina")
        {
            Destroy(other.gameObject);
            GM.instance.playerCurrentStamina += 10;
            if (GM.instance.playerCurrentStamina > GM.instance.playerTotalStamina)
            {
                GM.instance.playerCurrentStamina = GM.instance.playerTotalStamina;
            }
            GM.instance.UpdatePlayerStamina(0);
            GM.instance.GMUpdateStaminaBar();
        }
        else if (other.tag == "Money")
        {
            Destroy(other.gameObject);
            int howMuchMoneyCanWeGet = Random.Range(1, 5);
            GM.instance.playerMoney += howMuchMoneyCanWeGet;
            GM.instance.UpdatePlayerMoney(0);
        }
        else if (other.tag == "Sword")
        {
            Destroy(other.gameObject);
            GM.instance.doesHaveSword =true;
            PlayerStats.playerStats_intDoesHaveSword = 1;
            GM.instance.playerStrength += 5;
            animator.SetBool("IdleSwordLeft",true);
            animator.SetBool("IdleEmptyLeft", false);
            animator.SetBool("IdleEmptyRight", false);
            GM.instance.UpdateStrenght(0);
            if(GM.instance.doesHaveBoots==true)
            {
                animator.SetTrigger("IdleSwordAndBootsLeft");
            }
        }
        else if (other.tag == "Boots")
        {
            Destroy(other.gameObject);
            GM.instance.doesHaveBoots = true;
            PlayerStats.playerStats_intDoesHaveSword = 1;
            PlayerStats.playerStats_Moves += 1;
            GM.instance.playerMovesTotal += 1;
            GM.instance.playerMovesLeft += 1;
            //movesLeftThisTurn += 1; 
            animator.SetTrigger("IdleBootsLeft");
            GM.instance.UpdateMovesLeftText();
            if (GM.instance.doesHaveSword == true)
            {
                animator.SetTrigger("IdleSwordAndBootsLeft");
            }
        }
        else if (other.tag == "Enemy")
        {
            GM.instance.LoseThisMap();
        }
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
