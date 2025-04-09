using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 에디터에서 플레이 중일 땐 강제 종료
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 실제 빌드된 게임에서는 이걸로 종료
        Application.Quit();
#endif
    }
}
