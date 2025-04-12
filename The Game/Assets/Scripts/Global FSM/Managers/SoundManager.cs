using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private AudioClip mainMusicClip;
    private float savedMainMusicTime = 0f;
    private Coroutine fadeCoroutine;
    private AudioClip currentClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void SetMainMusic(AudioClip clip)
    {
        if (clip != null)
            mainMusicClip = clip;
    }

    public void PlayMusic(AudioClip clip, bool loop = true, float fadeTime = 0.5f)
    {
        if (clip == null) return;

        if (musicSource.isPlaying && musicSource.clip == mainMusicClip)
        {
            savedMainMusicTime = musicSource.time; // Ana müzikten geçişte zamanı kaydet
        }

        if (clip == musicSource.clip) return;

        currentClip = clip;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeInMusic(clip, loop, fadeTime));
    }

    public void RestoreMainMusic(float fadeTime = 0.5f)
    {
        if (mainMusicClip == null) return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeInMusic(mainMusicClip, true, fadeTime, savedMainMusicTime));
    }

    public void StopMusic(float fadeTime = 0.5f)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeOutMusic(fadeTime));
    }

    private IEnumerator FadeInMusic(AudioClip newClip, bool loop, float duration, float startAt = 0f)
    {
        if (musicSource.isPlaying)
        {
            yield return StartCoroutine(FadeOutMusic(duration / 2f));
        }

        musicSource.clip = newClip;
        musicSource.loop = loop;
        musicSource.time = startAt;
        musicSource.volume = 0f;
        musicSource.Play();

        float time = 0f;
        while (time < duration)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 1f;
    }

    private IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;
        float time = 0f;

        while (time < duration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = 0f;
        musicSource.Stop();
    }
}
