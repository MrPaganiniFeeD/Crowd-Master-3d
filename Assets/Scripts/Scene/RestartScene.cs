using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] private DeathState _deathState;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _deathState.Died += RestartLevel;
    }
    private void OnDisable()
    {
        _deathState.Died -= RestartLevel;
    }
    private void RestartLevel()
    {
        _coroutine = StartCoroutine(RestartDelay(1.9f));
    }
    private IEnumerator RestartDelay(float timeToRestart)
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene("EndBuild");
        //StopAllCoroutines();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            _coroutine = StartCoroutine(RestartDelay(1));
        }
    }

}
