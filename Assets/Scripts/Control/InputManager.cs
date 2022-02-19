using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask enemyMask; // enemy mask

    [SerializeField]
    private LayerMask groundMask; // ground mask

    //getting reference to the scripts
    private AttackEnemy attackEnemy;
    private MovementController movementController;

    //parameters
    private bool canAttack = true;
    private float delay = 0.5f;

    void Start()
    {
        attackEnemy = GetComponent<AttackEnemy>();
        movementController = GetComponent<MovementController>();
    }

    void Update()
    {
        manageMouseInput();
    }

    private void manageMouseInput()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            
            if (canAttack & Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, enemyMask)) // click on the enemy
            {
                StartCoroutine(AttackDelay());
                attackEnemy.enemyClicked(hit);

            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, groundMask)) // click on the ground
            {
                movementController.MovePlayer(hit.point);
            }
        }
    }
    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(delay);
        canAttack = true;
    }
}
