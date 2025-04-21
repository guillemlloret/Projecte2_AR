using UnityEngine;

public class InstrumentPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isTracking = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoopManager.instance.OnLoop += PlaySound;
    }

    private void OnDestroy()
    {
        if (LoopManager.instance != null)
            LoopManager.instance.OnLoop -= PlaySound;
    }

    public void SetTracking(bool tracking)
    {
        isTracking = tracking;
    }

    private void PlaySound()
    {
        if (isTracking && audioSource != null)
        {
            audioSource.Play();
        }
    }
}
