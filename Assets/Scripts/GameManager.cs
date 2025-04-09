using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject overUI;
    public GameObject winUI;
    public Text timeText;

    public Card firstCard;
    public Card secCard;

    public Board board;

    public int maxCardNum = 20;
    int cardNum;

    public float maxTime = 60f;
    public float warningTime = 30f;
    float timer;
    bool isRed;

    public bool isPlay;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        isPlay = true;
    }

    private void Start()
    {
        cardNum = maxCardNum;
        timer = maxTime;
        isRed = false;
        firstCard = null;
        secCard = null;
        AudioManager.instance.ChangeBgm(AudioManager.Bgm.Normal);
        AudioManager.instance.ControlBgm(true);
    }

    private void Update()
    {
        if (isPlay)
        {
            if (cardNum == 0)
                GameClear();

            timer -= Time.deltaTime;
            if (timer <= 0)
                GameOver();

            if (!isRed && timer <= warningTime)
                ChangeWarning();

            TimeTextUpdate();
        }
    }

    public void Match()
    {
        if(firstCard.index == secCard.index)
        {
            cardNum -= 2;
            firstCard.HideCard(1);
            secCard.HideCard(2);
        }
        else
        {
            firstCard.UndoCard();
            secCard.UndoCard();
        }
    }

    void TimeTextUpdate()
    {
        timeText.text = timer.ToString("N2");
    }

    void ChangeWarning()
    {
        isRed = true;
        timeText.color = Color.red;
        AudioManager.instance.ChangeBgm(AudioManager.Bgm.Warning);
        AudioManager.instance.ControlBgm(true);
    }

    void GameOver()
    {
        isPlay = false;
        timer = 0f;
        TimeTextUpdate();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.GameOver);
        AudioManager.instance.ControlBgm(false);

        StartCoroutine(ActiveOverUI());
    }

    void GameClear()
    {
        isPlay = false;
        AudioManager.instance.ControlBgm(false);

        Invoke("delayActiveWinUI", 1f);
    }

    void delayActiveWinUI()
    {
        winUI.SetActive(true);
    }

    IEnumerator ActiveOverUI()
    {
        yield return new WaitForSeconds(0.3f);
        board.ThrowAllCard();

        yield return new WaitForSeconds(0.7f);
        overUI.SetActive(true);
    }
}
