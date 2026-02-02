using Cysharp.Threading.Tasks;
using JFramework.Package;
using LitJson;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using TiktokGame;
using UnityEngine;
using YooAsset;

public class LaunchArgs
{
    public EPlayMode playMode;
    public string url;
    public string packageName;
}



public class TiktokLauncher : MonoBehaviour
{
    public enum ServerUrls
    {
        [LabelText("本地服务器")]
        Local,
        [LabelText("远程服务器")]
        Server
    }

    // Start is called before the first frame update
    /// <summary>
    /// 运行模式，决定资源加载方式
    /// </summary>
    public EPlayMode PlayMode = EPlayMode.EditorSimulateMode;

    /// <summary>
    /// 热更地址
    /// </summary>
    public string HotfixUrl;

    /// <summary>
    /// 热更资源包名
    /// </summary>
    public string PackageName;

    ///// <summary>
    ///// 服务器地址
    ///// </summary>
    //[SerializeField] string _serverUrl = "https://localhost:7289/";

    /// <summary>
    /// 游戏账号，如果不填就用设备唯一标识符
    /// </summary>
    [SerializeField] string _account = "jcw28";

    /// <summary>
    /// 目标服务器
    /// </summary>
    [SerializeField] ServerUrls _targetServer = ServerUrls.Local;

    public static string ServerUrl { get; private set; }
    public static string Account { get; private set; }

    void Start()
    {
        //aot丢失问题，这里引用一下
        var task = new List<UniTask>();
        var json = new List<PropertyMetadata>();
        var dic = new Dictionary<int, int>();


        ServerUrl = GetServerUrl(_targetServer);
        Account = _account;

        var extraData = new RunableExtraData() { Data = new LaunchArgs() { playMode = PlayMode, url = HotfixUrl, packageName = PackageName} };

        var initManager = new TiktokInitManager();
        //var routeManager = new RouteManager();
        var patchManager = new TiktokPatchManager();
        var gameManager = new TiktokGameManager();

        Queue<IRunable> runables = new Queue<IRunable>();
        runables.Enqueue(initManager);
        runables.Enqueue(patchManager);
        runables.Enqueue(gameManager);

        var launcher = new CommonLauncher(runables);
        launcher.Run(extraData);
    }

    string GetServerUrl(ServerUrls targetServer)
    {
        switch (targetServer)
        {
            case ServerUrls.Local:
                return "https://localhost:7289/";
            case ServerUrls.Server:
                return "https://1.117.228.69:7289/";
            default:
                return "https://localhost:7289/";
        }
    }
}
