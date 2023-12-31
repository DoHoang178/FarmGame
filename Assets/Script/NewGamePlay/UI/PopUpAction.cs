using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpAction : MonoBehaviour
{
    [SerializeField] private GameObject PanelPlant;
    [SerializeField] private Button btThuHoach;
    [SerializeField] private Button btTrongCay1;
    [SerializeField] private Button btTrongCay2;
    [SerializeField] private Button btTrongCay3;
    [SerializeField] private Button btTrongCay4;
    [SerializeField] private Button btTrongCay5;
    [SerializeField] private TextMeshProUGUI txtMessage;

    private GameItemId PlantId;
    public GameItemId Plant_Id;
    public GameItemId Id1;
    public GameItemId Id2;
    public GameItemId Id3;
    public GameItemId Id4;
    public GameItemId Id5;
    private GamePlayController gamePlayController;
    public void Init(GamePlayController controller, MudBehavior mud)
    {
        gamePlayController = controller;
        switch (mud.mudState)
        {
            case MudState.NONE:
                PanelPlant.gameObject.SetActive(true);
                btTrongCay1.onClick.RemoveAllListeners();
                btTrongCay1.onClick.AddListener(
                    delegate
                    {
                        PlantId = Id1;
                        mud.Plant(Id1);
                        PanelPlant.gameObject.SetActive(false);
                        txtMessage.gameObject.SetActive(true);
                        SetPlantId(Id1);
                        Debug.Log(Plant_Id);
                    });
                btTrongCay2.onClick.RemoveAllListeners();
                btTrongCay2.onClick.AddListener(
                    delegate
                    {
                        PlantId = Id2;
                        mud.Plant(Id2);
                        PanelPlant.gameObject.SetActive(false);
                        txtMessage.gameObject.SetActive(true);
                    });
                btTrongCay3.onClick.RemoveAllListeners();
                btTrongCay3.onClick.AddListener(
                    delegate
                    {
                        PlantId = Id3;
                        mud.Plant(Id3);
                        PanelPlant.gameObject.SetActive(false);
                        txtMessage.gameObject.SetActive(true);
                    });
                btTrongCay4.onClick.RemoveAllListeners();
                btTrongCay4.onClick.AddListener(
                    delegate
                    {
                        PlantId = Id4;
                        mud.Plant(Id4);
                        PanelPlant.gameObject.SetActive(false);
                        txtMessage.gameObject.SetActive(true);
                    });
                btTrongCay5.onClick.RemoveAllListeners();
                btTrongCay5.onClick.AddListener(
                    delegate
                    {
                        PlantId = Id5;
                        mud.Plant(Id5);
                        PanelPlant.gameObject.SetActive(false);
                        txtMessage.gameObject.SetActive(true);
                    });

                btThuHoach.gameObject.SetActive(false);
                txtMessage.gameObject.SetActive(false);
                break;
            case MudState.PLANTING:
                btThuHoach.gameObject.SetActive(false);
                PanelPlant.gameObject.SetActive(false);
                txtMessage.gameObject.SetActive(true);
                break;
            case MudState.DONE:
                btThuHoach.gameObject.SetActive(true);
                btThuHoach.onClick.RemoveAllListeners();
                btThuHoach.onClick.AddListener(
                    delegate
                    {
                        mud.Harvest();
                        PanelPlant.gameObject.SetActive(true);

                        btTrongCay1.onClick.RemoveAllListeners();
                        btTrongCay1.onClick.AddListener(
                            delegate
                            {
                                PlantId = Id1;
                                mud.Plant(Id1);
                                PanelPlant.gameObject.SetActive(false);
                                txtMessage.gameObject.SetActive(true);
                                SetPlantId(Id1);
                                Debug.Log(Plant_Id);
                            });
                        btTrongCay2.onClick.RemoveAllListeners();
                        btTrongCay2.onClick.AddListener(
                            delegate
                            {
                                PlantId = Id2;
                                mud.Plant(Id2);
                                PanelPlant.gameObject.SetActive(false);
                                txtMessage.gameObject.SetActive(true);
                            });
                        btTrongCay3.onClick.RemoveAllListeners();
                        btTrongCay3.onClick.AddListener(
                            delegate
                            {
                                PlantId = Id3;
                                mud.Plant(Id3);
                                PanelPlant.gameObject.SetActive(false);
                                txtMessage.gameObject.SetActive(true);
                            });
                        btTrongCay4.onClick.RemoveAllListeners();
                        btTrongCay4.onClick.AddListener(
                            delegate
                            {
                                PlantId = Id4;
                                mud.Plant(Id4);
                                PanelPlant.gameObject.SetActive(false);
                                txtMessage.gameObject.SetActive(true);
                            });
                        btTrongCay5.onClick.RemoveAllListeners();
                        btTrongCay5.onClick.AddListener(
                            delegate
                            {
                                PlantId = Id5;
                                mud.Plant(Id5);
                                PanelPlant.gameObject.SetActive(false);
                                txtMessage.gameObject.SetActive(true);
                            });
                        btThuHoach.gameObject.SetActive(false);
                    });
                PanelPlant.gameObject.SetActive(false);
                txtMessage.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void SetPlantId(GameItemId newId)
    {
        Plant_Id = newId;
    }
    public GameItemId GetPlantId()
    {
        return Plant_Id;
    }
}
