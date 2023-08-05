using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isEnter;
    private GamePlayController controller;
    public GameItemId gameItemId;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        controller = GameObject.Find("Controller").GetComponent<GamePlayController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (isEnter == false && other.tag == "Player")
        {
            isEnter = true;
            controller.ShowMenuAction(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnter = false;
            controller.HideMenuAction(this);
        }
    }

}
