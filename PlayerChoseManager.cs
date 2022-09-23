using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoseManager : MonoBehaviour
{
    public GameObject playerChosePrefab;
    public TurnController turnController;
    public Color[] playerColors;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //CreatePlayers();
        RegionsMaster.CreateRegions();
        //Camera.current.backgroundColor = playerColors[0];
        cam.backgroundColor = playerColors[0];
    }

    public void CreatePlayers()
    {
        for (int i = 0; i < turnController.playerCount; i++)
        {
            GameObject newObject = Instantiate(playerChosePrefab,transform);
            turnController.players.Add(newObject);
            PlayerController playerController = newObject.GetComponent<PlayerController>();
            playerController.color = playerColors[i];
            if (i != 0) newObject.SetActive(false);
            
        }
        //CreateDangeonMaster();
    }

    public void CreateDangeonMaster()
    {
        int difficulty = UnityEngine.Random.Range(1, 3);
        difficulty = 3;

        List<UnitBase> units = new List<UnitBase>() { new UnitPork() };
        List<ModificatorBase> mods = new List<ModificatorBase>();
        //for (int i = 0; i < difficulty; i++)
        //{
        //    units.Add(new UnitPork());
        //    
        //}
        Player _dangeonMaster = new Player(CharecterType.DangeonMaster, 4, 0, 0, 0, 0, units, mods, 100, 100, 8);
        _dangeonMaster.SavePlayer();
    }

}
