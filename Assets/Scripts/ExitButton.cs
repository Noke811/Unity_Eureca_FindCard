using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // �����Ϳ��� �÷��� ���� �� ���� ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ���� ����� ���ӿ����� �̰ɷ� ����
        Application.Quit();
#endif
    }
}
