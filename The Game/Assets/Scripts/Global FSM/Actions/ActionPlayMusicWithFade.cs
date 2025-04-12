using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Play Music With Fade")]
    public class ActionPlayMusicWithFade : FSMAction
    {
        public AudioClip musicClip;
        public bool setAsMainTheme = false;
        public bool loop = true;
        public float fadeTime = 0.5f;

        public override void Act(FSMContext context)
        {
            if (setAsMainTheme)
                SoundManager.Instance.SetMainMusic(musicClip);

            SoundManager.Instance.PlayMusic(musicClip, loop, fadeTime);
        }
    }
}