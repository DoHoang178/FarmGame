using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private PopUpAction popupActionPref;
    [SerializeField] private PopUpActionCollect popupActionCollectPref;
    [SerializeField] private GameObject RootUI;
    [SerializeField] private MenuItems menuGameItems;
    private PopUpAction popupAction;
    private PopUpActionCollect popupActionCollect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowMenuAction(MudBehavior mud)
    {
        popupAction = Instantiate(popupActionPref, RootUI.transform);
        popupAction.Init(this, mud);
    }
    public void HideMenuAction(MudBehavior mud)
    {
        Destroy(popupAction.gameObject);
    }
    public void ShowMenuAction(Collectable collect)
    {
        popupActionCollect = Instantiate(popupActionCollectPref, RootUI.transform);
        popupActionCollect.Init(this, collect);
    }
    public void HideMenuAction(Collectable collect)
    {
        Destroy(popupActionCollect.gameObject);
    }
    public void ShowGameItem()
    {
        menuGameItems.gameObject.SetActive(true);
        menuGameItems.ShowGameItem();
    }
}