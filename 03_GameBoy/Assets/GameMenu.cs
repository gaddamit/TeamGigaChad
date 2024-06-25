using UnityEngine;
using UnityEngine.Events;
using GBTemplate;

public class GameMenu : MonoBehaviour
{
    public GameObject cursor;
    public UnityEvent[] menuOptions;
    private GBConsoleController gb;
    public AudioClip[] audioClips;
    private int _optionCount;
    private int _currentOption = 0;
    [SerializeField] private float _cursorOffsetY = 1.0f;
    private void Awake()
    {
        if(menuOptions?.Length != 0)
        {
            _optionCount = menuOptions.Length;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Getting the instance of the console controller, so we can access its functions
        gb = GBConsoleController.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gb.Input.UpJustPressed)
        {
            MoveUp();
        }
        if(gb.Input.DownJustPressed)
        {
            MoveDown();
        }
        if(gb.Input.ButtonAJustPressed)
        {
            menuOptions[_currentOption].Invoke();
        }
    }

    private void MoveUp()
    {
        if(_currentOption > 0)
        {
            cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursor.transform.localPosition.y + _cursorOffsetY, cursor.transform.localPosition.z);
            _currentOption--;
        }
    }

    private void MoveDown()
    {
        if(_currentOption < _optionCount - 1)
        {
           cursor.transform.localPosition = new Vector3(cursor.transform.localPosition.x, cursor.transform.localPosition.y - _cursorOffsetY, cursor.transform.localPosition.z);
            _currentOption++;
        }
    }
}
