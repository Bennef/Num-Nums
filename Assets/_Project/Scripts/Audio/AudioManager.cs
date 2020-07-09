using UnityEngine;

namespace Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip _crash;
        [SerializeField] AudioClip[] _catSounds;

        public AudioClip Crash { get => _crash; }

        public AudioSource ASrc { get; set; }
        public AudioClip[] CatSounds { get => _catSounds; }

        void Start() => ASrc = GetComponent<AudioSource>();

        public void PlaySound(AudioClip soundToPlay) => ASrc.PlayOneShot(soundToPlay);

        public void PlayRandomSound(AudioClip[] clipArray)
        {
            int index = Random.Range(0, clipArray.Length);
            ASrc.PlayOneShot(clipArray[index]);
        }
    }
}