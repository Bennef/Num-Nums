using UnityEngine;

namespace Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _crash, _numNum1;

        public AudioClip Crash { get => _crash; }
        public AudioClip Numnum1 { get => _numNum1; }

        public AudioSource ASrc { get; set; }

        void Start()
        {
            ASrc = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioSource aSrc, AudioClip soundToPlay) => aSrc.PlayOneShot(soundToPlay);
        /*
        public void StopSound(AudioSource aSrc) => aSrc.Stop();

        public bool IsPlaying(AudioSource aSrc)
        {
            if (aSrc.isPlaying)
                return true;
            return false;
        }*/
    }
}