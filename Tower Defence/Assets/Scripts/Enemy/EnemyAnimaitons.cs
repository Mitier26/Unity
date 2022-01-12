using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimaitons : MonoBehaviour
{
    private Animator _animator;

    void Update()
    {
        _animator = GetComponent<Animator>();
    }

    private void PlayHurtAnimation()
    {
        _animator.SetTrigger("Hurt");
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger("Die");
    }
}
