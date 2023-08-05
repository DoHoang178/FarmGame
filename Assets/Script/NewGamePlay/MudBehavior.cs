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
    [SerializeField] private List<Transform> mudObjects;
    public GameItemId gameItemId;
    public int id;
    public float time = 0;
    public MudState mudState = MudState.NONE;
    public int completeTime = 30;
    public float mudScale = 0.8f;
    private bool isEnter;
    public PopUpAction popUpAction;

    private void Start()
    {
        isEnter = false;
        controller = GameObject.Find("Controller").GetComponent<GamePlayController>();

    }
    public void Plant()
    {
        if (mudState != MudState.PLANTING)
        {
            bool rs = true; //PlayerProfile.Instance.DecreaseCoin(200);
            bool rs1 = true; //PlayerProfile.Instance.UseGameItem(gameItemId);

            if (rs && rs1)
            {
                //Instantiate(DataManger.Instance.GetItemPrefab(popUpAction.PlantId));
                //SpawnPlant(popUpAction.PlantId,)
                foreach (Transform data in mudObjects)
                {
                    SpawnPlant(popUpAction.PlantId, data.position.x, data.position.y, data.position.z);
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
            PlayerProfile.Instance.AddGameItem(gameItemId, 10);
            mudState = MudState.NONE;
            time = 0;
            float scaleVal = 0.01f;
            foreach (Transform item in mudObjects)
            {
                item.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
            }
        }
    }

    private void Update()
    {
        if (mudState == MudState.PLANTING)
        {
            time += Time.deltaTime;
        }
        if (time > completeTime)
        {
            mudState = MudState.DONE;
        }
        else
        {
            var scaleVal = time / completeTime * mudScale;
            foreach (Transform item in mudObjects)
            {
                item.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
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
    public void SpawnPlant(GameItemId id, float x, float y, float z)
    {
        Instantiate(DataManger.Instance.GetItemPrefab(id), new Vector3(x, y, z), Quaternion.identity);
    }
}
