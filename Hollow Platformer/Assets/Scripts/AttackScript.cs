using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

  public float attackRange = 4f;
  public Transform attackPoint;
  public LayerMask attackableLayers;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetButtonDown("Attack")){
      Debug.Log("Attack!");
      Attack();
    }
  }

  void Attack(){
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackableLayers);
    if(hitEnemies == null)
      return;
    foreach(Collider2D enemy in hitEnemies){
      enemy.GetComponent<TempEnemyScript>().TakeDamage(10);
    }
  }

  void OnDrawGizmos(){
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}
