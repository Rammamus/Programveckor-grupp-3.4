using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    PlayerCombat player;
    Vector2 direction;
    public float damage;
    public float speed;
    float lifeTime = 5;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        damage = FireflyCombat.FindObjectOfType<FireflyCombat>().attackDMG;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.PlayerTakeDMG(damage);
        }
        Destroy(this.gameObject);
    }
}
