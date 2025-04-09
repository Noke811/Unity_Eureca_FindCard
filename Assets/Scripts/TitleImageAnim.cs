using UnityEngine;

public class TitleImageAnim : MonoBehaviour
{
    public Sprite[] photos;

    SpriteRenderer spriter;

    public float period;
    float timer = 0f;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= period)
        {
            timer = 0f;
            spriter.sprite = photos[Random.Range(0, photos.Length)];
        }
    }
}
