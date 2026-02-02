using TMPro;
using UnityEngine;

namespace Tiktok
{
    public class TiktokGameControllerTest : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] TextMeshProUGUI txtTest;
        void Start()
        {
            txtTest.text = "hello world!!!!!!!!!";
        }

        // Update is called once per frame
        void Update()
        {

        }

    }

}
