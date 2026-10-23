using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public AudioClip levelCompleteStringer;
    public AudioClip levelCompleteMusic;
    private AudioSource goalAudioSource;
    // private float levelCompleteVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goalAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // levelCompleteVolume = SoundManager.bgmVolume;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (LevelUIManager.Instance != null)
            {
                LevelUIManager.Instance.Wins();
                // levelCompleteVolume = SoundManager.bgmVolume;
                // Debug.Log("BGM Volume: " + levelCompleteVolume);
                SoundManager.managerAudioSource.Stop();
                goalAudioSource.PlayOneShot(levelCompleteStringer, 0.5f);
                goalAudioSource.PlayDelayed(1.2f);
                // goalAudioSource.PlayOneShot(levelCompleteMusic, 0.5f);
            }
        }
    }
}
