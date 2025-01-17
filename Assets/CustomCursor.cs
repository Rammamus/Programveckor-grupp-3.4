using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    /*[SerializeField] Texture2D cursorTexture;
    Vector2 cursorHotspot;*/

    [SerializeField] GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        /*cursorHotspot = new Vector2(2, 0);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);*/
    }

    private void Update()
    {
        Cursor.visible = false;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x += .1f;
        mousePosition.y -= .195f;
        mousePosition.z = 0;
        cursor.transform.position = mousePosition;
    }


}
