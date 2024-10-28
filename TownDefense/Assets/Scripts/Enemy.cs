
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 dir;
    [SerializeField] private Animator anim;
    private CapsuleCollider2D capsuleCollider;
    private int health = 2;
    // Start is called before the first frame update
    bool agred = false;
    private void Start()
    {
        dir = dir * Random.Range(1f, 2f);
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && agred == false)
        {
            agred = true;
            StartCoroutine(Fighting(collision.GetComponent<Knight>()));
        }
        if (collision.CompareTag("Player2") && agred == false)
        {
            
            StartCoroutine(Fighting2(collision.GetComponent<Knight>()));
        }
        if (collision.CompareTag("Town"))
        {
            FindFirstObjectByType<PlayAgain>().Show();           
        }

    }
    IEnumerator Fighting(Knight warrior)
    {
        warrior.dir = dir * 0;
        warrior.anim.SetTrigger("Attack");
        warrior.coll.enabled = false;
        capsuleCollider.enabled = false;
        dir = dir * 0;
        anim.SetTrigger("Attack");
        this.GetComponent<Enemy>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        anim.SetTrigger("Death");
        warrior.anim.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        
    }
    IEnumerator Fighting2(Knight warrior)
    {
        warrior.dir = dir * 0;
        warrior.anim.SetTrigger("Attack");
        warrior.coll.enabled = false;
        health -= 1;
        if(health <= 0)
        {
            agred = true;
            capsuleCollider.enabled = false;
            dir = dir * 0;
            anim.SetTrigger("Attack");
            this.GetComponent<Enemy>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            anim.SetTrigger("Death");
        }
        yield return new WaitForSeconds(1);

    }
}
