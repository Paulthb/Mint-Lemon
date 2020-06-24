using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private List<AcidSpawner> spawnerList = null;

    [SerializeField]
    private List<Transform> acidDropPosList = null;

    [SerializeField]
    private List<Transform> holesPosList = null;

    [SerializeField]
    private GameObject paillePrefab = null;


    #region Singleton Pattern
    private static EventManager _instance;

    public static EventManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AcidDrop();
    }

    public void AcidDrop()
    {
        int randSpawnerId = Random.Range(0, spawnerList.Count - 1);
        int randAcidPosId = Random.Range(0, acidDropPosList.Count - 1);

        //Debug.Log(randSpawnerId);
        //Debug.Log(randAcidPosId);

        spawnerList[randSpawnerId].SpawnAcid(acidDropPosList[randAcidPosId]);
    }

    public void HoleDrop()
    {
        int randHolesPosId = Random.Range(0, holesPosList.Count - 1);
        Instantiate(paillePrefab, holesPosList[randHolesPosId].position, Quaternion.identity);
    }
}
