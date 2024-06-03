using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Aquí puedes agregar lógica para lo que sucede cuando termina el video, si es necesario
    }

    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            // Obtén el frame actual del video y asígnalo al Raw Image
            rawImage.texture = videoPlayer.texture;
        }
    }
}
