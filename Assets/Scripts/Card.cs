using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int index;

    public GameObject cardImage;
    public GameObject hideImage;
    public Sprite[] photos;

    public Button btn;

    Animator animator;
    Rigidbody2D rigid;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void InitImage(int idx)
    {
        index = idx;
        cardImage.GetComponent<Image>().sprite = photos[index];
    }

    public void FlipCard()
    {
        if (!GameManager.instance.isPlay)
            return;

        if(GameManager.instance.secCard == null)
        {
            btn.interactable = false;
            animator.SetBool("Selected", true);
            cardImage.SetActive(true);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.CardFlip);

            if(GameManager.instance.firstCard == null)
                GameManager.instance.firstCard = this;
            else
            {
                GameManager.instance.secCard = this;
                GameManager.instance.Match();
            }
        }
    }

    public void UndoCard()
    {
        Invoke("InvokeUndoCard", 0.5f);
    }

    void InvokeUndoCard()
    {
        animator.SetBool("Selected", false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.CardWrong);
        btn.interactable = true;
        cardImage.SetActive(false);
        GameManager.instance.firstCard = null;
        GameManager.instance.secCard = null;
    }

    public void HideCard(int flag)
    {
        if(flag == 1)
            GameManager.instance.firstCard = null;
        else
            GameManager.instance.secCard = null;

        Invoke("InvokeHideCard", 0.5f);
    }

    void InvokeHideCard()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.CardCorrect);
        hideImage.SetActive(true);
        cardImage.SetActive(false);
    }

    public void ThrowCardAnim()
    {
        animator.SetTrigger("Over");

        rigid.gravityScale = 1.0f;
        Vector2 dir = Random.value < 0.5f ? Vector2.up + Vector2.left : Vector2.up + Vector2.right;
        rigid.AddForce(dir * 200 * Random.value);
    }
}
