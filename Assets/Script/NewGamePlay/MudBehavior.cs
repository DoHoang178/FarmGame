using System.Collections.Generic;
using UnityEngine;
public enum MudState
{
    NONE,
    PLANTING,
    DONE
}
public class MudBehavior : MonoBehaviour
{
    private GamePlayController controller;
    [SerializeField] private List<GameObject> mudObjects;
    public GameItemId gameItemId;
    public int id;
    public float time = 0;
    public MudState mudState = MudState.NONE;
    public int completeTime = 30;
    public float mudScale = 0.8f;
    private bool isEnter;
    public PopUpAction popUpAction;

    GameItemId cacheIdItem;

    private void Start()
    {
        isEnter = false;
        controller = GameObject.Find("Controller").GetComponent<GamePlayController>();

    }
    public void Plant(GameItemId idpalnt)
    {
        if (mudState != MudState.PLANTING)
        {
            bool rs = PlayerProfile.Instance.DecreaseCoin(1000);
            bool rs1 = true; //PlayerProfile.Instance.UseGameItem(gameItemId);
            cacheIdItem = idpalnt;
            Debug.Log(popUpAction.Plant_Id);
            if (rs && rs1)
            {
                //Instantiate(DataManger.Instance.GetItemPrefab(popUpAction.PlantId));
                //SpawnPlant(popUpAction.PlantId,)
                foreach (GameObject data in mudObjects)
                {
                    //Destroy(data);
                    SpawnPlant(idpalnt, data.transform.position.x, data.transform.position.y, data.transform.position.z, mudObjects[mudObjects.IndexOf(data)].transform);

                }
                mudState = MudState.PLANTING;
                time = 0;
            }
            else
            {
                Debug.LogWarning("Khong du tien hoac hat giong");
            }
        }
        else
        {
            Debug.Log("warning");
        }

    }
    public void Harvest()
    {
        if (mudState == MudState.DONE)
        {
            PlayerProfile.Instance.IncreaseCoin(1000);
            PlayerProfile.Instance.AddGameItem(cacheIdItem, 10);
            cacheIdItem = GameItemId.NONE;
            mudState = MudState.NONE;
            time = 0;
            foreach (GameObject item in mudObjects)
            {
                Destroy(item.transform.GetChild(0).gameObject);
            }
        }
    }

    private void Update()
    {
        if (mudState == MudState.PLANTING)
        {
            time += Time.deltaTime;
            if (time > completeTime)
            {
                mudState = MudState.DONE;
            }
            else
            {
                Debug.Log("update");
                var scaleVal = time / completeTime * mudScale;
                foreach (GameObject item in mudObjects)
                {

                    item.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                    Debug.Log(scaleVal);
                }
            }
        }

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
    public void SpawnPlant(GameItemId id, float x, float y, float z, Transform parent)
    {
        var plt = Instantiate(DataManger.Instance.GetItemPrefab(id), new Vector3(x, y, z), Quaternion.identity);
        plt.transform.SetParent(parent);
    }
}
