using UnityEngine;
using UnityEngine.EventSystems;

public class SomArrastar : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public AudioClip somArrastar;

    private AudioSource audioSource;
    private bool tocando = false;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();

        if (audioSource != null)
        {
            audioSource.loop = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!tocando && audioSource != null && somArrastar != null)
        {
            audioSource.clip = somArrastar;
            audioSource.Play();

            tocando = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        tocando = false;
    }
}