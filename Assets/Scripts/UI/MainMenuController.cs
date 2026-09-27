using UnityEngine;

namespace Afterimage.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource ambienceSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip underwaterAmbience;
        [SerializeField] private AudioClip boostSound;
        [SerializeField] private AudioClip collectibleSound;
        [SerializeField] private AudioClip impactSound;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlayAmbient(AudioClip clip)
        {
            if (ambienceSource == null || clip == null)
            {
                return;
            }

            ambienceSource.clip = clip;
            ambienceSource.loop = true;
            ambienceSource.Play();
        }

        public void PlaySfx(AudioClip clip)
        {
            if (sfxSource == null || clip == null)
            {
                return;
            }

            sfxSource.PlayOneShot(clip);
        }

        public void PlayBoostSfx()
        {
            PlaySfx(boostSound);
        }

        public void PlayCollectibleSfx()
        {
            PlaySfx(collectibleSound);
        }

        public void PlayImpactSfx()
        {
            PlaySfx(impactSound);
        }
    }
}
