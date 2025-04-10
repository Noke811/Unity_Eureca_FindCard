using UnityEngine;

public class Test_DeletePrefs : MonoBehaviour
{
    public void TestDeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Application.Quit(); // 재시작 유도
    }
}
