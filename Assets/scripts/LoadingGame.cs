using UnityEngine;
using UnityEngine.UI;

public class LoadingGame : MonoBehaviour {

    //public Vector2 position = new Vector2(308f, 323f);
    public Vector2 size = new Vector2(350f, 50f);
    //public Texture2D emptyProgress;
    public Texture2D fullProgess;
    public float paddingX = 167;
    public float paddingY = -30;
    public Text text;

    private void OnGUI()
    {
        //GUI.DrawTexture(new Rect(text.transform.position.x - paddingX, text.transform.position.y - paddingY, size.x, size.y), emptyProgress);
        GUI.DrawTexture(new Rect(text.transform.position.x - paddingX, text.transform.position.y - paddingY, size.x * Mathf.Clamp(GameControllStart.instance.progress, 0f, 0.97f), size.y - 4f), fullProgess);
    }
}
