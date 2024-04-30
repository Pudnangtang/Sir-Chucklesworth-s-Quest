using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public float scrollSpeed = 20f;
    private TextMeshProUGUI tmpText;
    public float fadeOutHeight;
    public float startHeight;

    private void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        startHeight = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        if (transform.position.y >= startHeight + fadeOutHeight)
        {
            float alpha = Mathf.Clamp01(1 - (transform.position.y - (startHeight + fadeOutHeight)) / fadeOutHeight);
            tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, alpha);
        }
    }
}
