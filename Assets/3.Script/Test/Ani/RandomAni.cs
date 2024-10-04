using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAni : StateMachineBehaviour
{
    [Header("Paramter Name")]
    [SerializeField] private string stateParameterName;

    [Header("Blend Time")]
    [SerializeField] private float blendDuration = 0.5f;

    [Space(50)]
    [Header("Clip Time")]
    [SerializeField] private float[] clipLengths;

    private AnimatorBlender animBlender;

    private float currentDelay;
    private int currentClipIndex;

    private bool IsAlreadyExecuted = false;

    private void RefreshClip()
    {
        currentClipIndex = Random.Range(0, clipLengths.Length);
        currentDelay = clipLengths[currentClipIndex];
    }

    private void PlayUpdatedClip(Animator animator)
    {
        RefreshClip();

        animBlender.BlendLerp(animator, stateParameterName, currentClipIndex, blendDuration);
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (IsAlreadyExecuted) { return; }

        animBlender = animator.GetComponent<AnimatorBlender>();

        RefreshClip();

        IsAlreadyExecuted = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0f) { PlayUpdatedClip(animator); }
    }
}
