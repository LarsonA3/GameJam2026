using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class CustomCursor : MonoBehaviour {
  public Sprite sprHover;
  public Color clrHover;

  private Sprite sprDefault;
  private Color clrDefault;
  private Image img;
  private PlayerTelepathy telepathy;

  private void Awake() {
    img = GetComponent<Image>();
    sprDefault = img.sprite;
    clrDefault = img.color;
    telepathy = FindFirstObjectByType<PlayerTelepathy>();
  }

  private void Update() {
    img.sprite = sprDefault;
    img.color = clrDefault;

    float range;
    if (telepathy != null)
      range = telepathy.grabRange;
    else
      range = 5f;
    var ray = Camera.main.ScreenPointToRay(transform.position);
    if (Physics.Raycast(ray, out RaycastHit hit, range)) {
      if (hit.collider.CompareTag("PushableObject")) {
        img.sprite = sprHover;
        img.color = clrHover;
      }
    }
  }
}
