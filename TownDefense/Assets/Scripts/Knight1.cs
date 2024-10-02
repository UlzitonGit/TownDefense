using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight1 : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] public Vector3 dir;
    public CapsuleCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        dir = dir * Random.Range(1f, 2f);
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
}
