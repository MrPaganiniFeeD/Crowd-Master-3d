using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public Player Player { get; private set; }

    public IAttack AttackBehaviour { get; private set; }
    public IMovable MoveBehaviour { get; private set; }

    public Rigidbody SelfRigidbody { get; private set; }
    public Animator SelfAnimation { get; private set; }



    private void Awake()
    {
        AttackBehaviour = GetComponent<IAttack>();
        MoveBehaviour = GetComponent<IMovable>();
        SelfRigidbody = GetComponent<Rigidbody>();
        SelfAnimation = GetComponent<Animator>();
        Player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        
    }
    public void InitPlayer(Player player)
    {
        
    }
    public abstract void Enter();
    public abstract void Exit();


    
}
