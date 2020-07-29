using System.Collections;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour, IEffect
{
    public AnimationCurve slowMoCurve;

    private Coroutine _effectCoroutine;

    public void PlayEffect()
    {
        if (_effectCoroutine != null)
        {
            StopCoroutine(_effectCoroutine);

            _effectCoroutine = null;
        }

        _effectCoroutine = StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        float duration = slowMoCurve.keys[slowMoCurve.length - 1].time;

        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            Time.timeScale = slowMoCurve.Evaluate(time);

            yield return null;
        }

        _effectCoroutine = null;
    }
}
