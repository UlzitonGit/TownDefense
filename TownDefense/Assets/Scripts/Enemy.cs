
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] Animator anim;
    CapsuleCollider2D capsuleCollider;
    // Start is called before the first frame update
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
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Fighting(collision.GetComponent<Knight>()));
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
        yield return new WaitForSeconds(1);
        
    }
}
