using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyScript : MonoBehaviour
{

  public float speed = 3f;
  public PlayerStats ps;
  public Transform player;
  public int health = 30;

  // Start is called before the first frame update
  void Start()
  {

  }

  void OnEnable(){
    if(player == null){
      player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
      ps = player.GetComponent<PlayerStats>();
    }
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      ps.TakeDamage();
    }
  }

  public void TakeDamage(int dam){
    health -= dam;
    Debug.Log("You Hit!! Enemy Health : " + health);

    if(health <= 0){
      Destroy(this.gameObject);
    }

    Vector2 pos = transform.position;
    pos.x += 2;
    transform.position = pos;
  }
}
