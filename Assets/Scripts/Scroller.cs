using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    void Update()
    {
        Vector2 offset = new Vector2(_x, _y) * Time.deltaTime;
        _img.uvRect = new Rect(_img.uvRect.position + offset, _img.uvRect.size);

        // Mirror the texture in the horizontal direction
        if (_img.uvRect.x < 0 || _img.uvRect.x + _img.uvRect.width > 1)
        {
            _x = -_x; // Reverse the direction to create a mirror effect
        }
    }
}
