using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBlender : MonoBehaviour
{
    public void BlendLerp(Animator animator, string parameterName, float toAnimState, float duration)
    {
        if (duration == -1)
        {
            animator.SetFloat(parameterName, toAnimState);
            return;
        }

        StartCoroutine(SetState(animator, parameterName, toAnimState, duration));
    }

    private IEnumerator SetState(Animator animator, string parameterName, float toAnimState, float duration)
    {
        float process = 0;
        float currentState = animator.GetFloat(parameterName);

        while (true)
        {
            animator.SetFloat(parameterName, Mathf.Lerp(currentState, toAnimState, process));

            process += Time.deltaTime / duration;

            if (process > 1.0f)
            {
                animator.SetFloat(parameterName, toAnimState);
                yield break;
            }
            yield return null;
        }
    }
}
