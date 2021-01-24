using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);

        mousePosition.x = mousePosition.x - transform.position.x;
        mousePosition.y = mousePosition.y - transform.position.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;  
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180+angle));
    }
}
