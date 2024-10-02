
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector3 dir;
    [SerializeField] private Animator anim;
    private CapsuleCollider2D capsuleCollider;
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
            agred = true;
            StartCoroutine(Fighting2(collision.GetComponent<Knight1>()));
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
        yield return new WaitForSeconds(1);
        
    }
    IEnumerator Fighting2(Knight1 warrior)
    {
        
        capsuleCollider.enabled = false;
        dir = dir * 0;
        anim.SetTrigger("Attack");
        this.GetComponent<Enemy>().enabled = false;
        yield return new WaitForSeconds(1);

    }
}
