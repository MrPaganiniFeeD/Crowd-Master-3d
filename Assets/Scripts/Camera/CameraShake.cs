using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private HealthContainer _healthContainer;

    [SerializeField] private int _range;
    [SerializeField] private int _speed;
    


    private Coroutine _coroutine;

    private void OnEnable()
    {
        _healthContainer.ApplyDamage += OnPlayerDamage;
    }
    private void OnDisable()
    {
        _healthContainer.ApplyDamage -= OnPlayerDamage;
    }
    private IEnumerator Shake()
    {
        int shakeRange = _range;
        Quaternion targetRotation;

        while(shakeRange != 0)
        {
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, shakeRange);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime);

            if (transform.rotation == targetRotation)
                shakeRange = (Mathf.Abs(shakeRange) - 1) * -1;

            yield return new WaitForEndOfFrame();
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        _coroutine = null;


    }
    private void OnPlayerDamage()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Shake());
    }

}
