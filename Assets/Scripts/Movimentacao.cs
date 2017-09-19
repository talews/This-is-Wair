using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {
	public float speed;
    public float rspeed;
    Rigidbody rbjogador;
    int pisoMask;
    Animator anim;
    Vector3 movimento;


	// Use this for initialization
	void Start () {
		
        rbjogador = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pisoMask = LayerMask.GetMask("piso");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float horizontal = Input.GetAxisRaw("Horizontal") * rspeed;
		float vertical = Input.GetAxisRaw("Vertical") * speed;
        Mov(horizontal,vertical);
        Animar(horizontal,vertical);
        transform.Translate(0, 0, vertical);
        transform.Rotate(0, horizontal, 0);

		
	}
    void Mov(float h, float v)
    {
     
        movimento.Set(h,0f, v);    
        movimento = movimento.normalized * speed * Time.deltaTime;
        rbjogador.MovePosition(transform.position + movimento); 
    }
    void Animar(float h,float v)
    {
        bool parado = ((v == 0) && (h == 0));
        anim.SetBool("estaAndando",!parado);
    }  
}
