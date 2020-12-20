using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 5;
    public int damage = 10;

    public void TakeDamage(){
      health -= 1;
      Debug.Log("Health "+health);
      if(health <= 0){
        Debug.Log("Dead");
        health = 5;
      }
    }
}
