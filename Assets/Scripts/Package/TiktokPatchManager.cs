using Cysharp.Threading.Tasks;
using JFramework.Package;
using System;
using System.IO;
//using TiktokGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

namespace TiktokGame
{
    public class TiktokPatchManager : BaseRunable
    {
        TiktokPatchView patchViewer;
        protected override async void OnRun(RunableExtraData extraData)
        {
            base.OnRun(extraData);

            Debug.Log("patch");
            SceneManager.LoadScene("Patch");

            Debug.Log("加载完成");

            // 初始化资源系统
            YooAssets.Initialize();

            //var package = YooAssets.TryGetPackage(GetPackageName());
            //if (package == null)
            //    package = YooAssets.CreatePackage(GetPackageName());

            //// 设置该资源包为默认的资源包，可以使用YooAssets相关加载接口加载该资源包内容。
            //YooAssets.SetDefaultPackage(package);


            var result = await InitPackage();

            // 获取指定的资源包，如果没有找到不会报错
            //var package = YooAssets.GetPackage(GetPackageName());

            var go = GameObject.Find("Canvas/Image/Image");
            Debug.Assert(go != null, "找不到补丁界面");
            patchViewer = go.GetComponent<TiktokPatchView>();

            Debug.Log("完成更新");


            //开始热更
            await RunPatch();


#if !UNITY_EDITOR
        //加载dllmanager
        var dllManager = new DllManager();
        await dllManager.LoadDLL();
#endif

            Debug.Log("加载DLL完成");
            NotifyComplete(this);
        }

        private async UniTask RunPatch()
        {
            Debug.Log("开始补丁更新...");

            var version = await RequestPackageVersion(GetPackageName());
            if (version == null)
            {
                throw new Exception("更新版本号失败 跳出逻辑");
            }
            await UpdatePackageManifest(version);
            var downloader = CreateDownloader(GetPackageName());

            //需要下载的文件总数和总大小
            int totalDownloadCount = downloader.TotalDownloadCount;
            long totalDownloadBytes = downloader.TotalDownloadBytes;

            //注册回调方法
            downloader.OnDownloadErrorCallback = OnDownloadErrorFunction;
            downloader.OnDownloadProgressCallback = OnDownloadProgressUpdateFunction;
            downloader.OnDownloadOverCallback = OnDownloadOverFunction;
            downloader.OnStartDownloadFileCallback = OnStartDownloadFileFunction;

            await Download(downloader);
        }

        private void OnStartDownloadFileFunction(string fileName, long sizeBytes)
        {
            Debug.Log($"开始下载文件 : {fileName} , 大小 : {sizeBytes}");
        }

        private void OnDownloadOverFunction(bool isSucceed)
        {
            if(isSucceed)
            {
                Debug.Log("下载完成");
                patchViewer.Refresh(1f);
            }
         
            else
                Debug.LogError("下载失败");
        }

        private void OnDownloadProgressUpdateFunction(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes, long currentDownloadBytes)
        {
            Debug.Log($"下载进度 : {currentDownloadCount}/{totalDownloadCount} , 大小 : {currentDownloadBytes}/{totalDownloadBytes}");

            float progress = (float)currentDownloadBytes / totalDownloadBytes;
            patchViewer.Refresh(progress);
        }

        private void OnDownloadErrorFunction(string fileName, string error)
        {
            Debug.LogError(error);
        }





        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private async UniTask<bool> InitPackage()
        {
            var playMode = GetPlayMode();// (EPlayMode)_machine.GetBlackboardValue("PlayMode");
            var packageName = GetPackageName(); //(string)_machine.GetBlackboardValue("PackageName");
            var buildPipeline = GetBuildPipline(); //(string)_machine.GetBlackboardValue("BuildPipeline");

            // 创建资源包裹类
            var package = YooAssets.TryGetPackage(packageName);
            if (package == null)
                package = YooAssets.CreatePackage(packageName);

            YooAssets.SetDefaultPackage(package);

            // 编辑器下的模拟模式
            InitializationOperation initializationOperation = null;
            Debug.Log(playMode);

            if (playMode == EPlayMode.EditorSimulateMode)
            {
                
                var simulateBuildResult = EditorSimulateModeHelper.SimulateBuild(buildPipeline, packageName);
                var createParameters = new EditorSimulateModeParameters();
                createParameters.EditorFileSystemParameters = FileSystemParameters.CreateDefaultEditorFileSystemParameters(simulateBuildResult);
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // 单机运行模式
            if (playMode == EPlayMode.OfflinePlayMode)
            {

                var createParameters = new OfflinePlayModeParameters();
                createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // 联机运行模式
            if (playMode == EPlayMode.HostPlayMode)
            {
                string defaultHostServer = GetHostServerURL();
                string fallbackHostServer = GetHostServerURL();
                Debug.Log("HostServer " + GetHostServerURL());
                IRemoteServices remoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
                var createParameters = new HostPlayModeParameters();
                createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                createParameters.CacheFileSystemParameters = FileSystemParameters.CreateDefaultCacheFileSystemParameters(remoteServices);
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // WebGL运行模式
            if (playMode == EPlayMode.WebPlayMode)
            {
                var createParameters = new WebPlayModeParameters();
                createParameters.WebFileSystemParameters = FileSystemParameters.CreateDefaultWebFileSystemParameters();
                initializationOperation = package.InitializeAsync(createParameters);
            }

            Debug.Log("当前使用 " + playMode);

            await initializationOperation;

            // 如果初始化失败弹出提示界面
            if (initializationOperation.Status != EOperationStatus.Succeed)
            {
                Debug.LogWarning($"{initializationOperation.Error}");
                //PatchEventDefine.InitializeFailed.SendEventMessage();
                return true;
            }
            else
            {
                //_machine.ChangeState<FsmUpdatePackageVersion>();
                return false;
            }
        }


        /// <summary>
        /// 请求资源版本号并更新
        /// </summary>
        /// <returns></returns>
        private async UniTask<string> RequestPackageVersion(string packageName)
        {
            var package = YooAssets.GetPackage(packageName);
            var operation = package.RequestPackageVersionAsync();
            await operation;

            if (operation.Status == EOperationStatus.Succeed)
            {
                //更新成功
                string packageVersion = operation.PackageVersion;
                Debug.Log($"Request package Version : {packageVersion}");
                return packageVersion;
            }
            else
            {
                //更新失败
                Debug.LogError(operation.Error);
                return null;
            }
        }

        /// <summary>
        /// 更新清单文件
        /// </summary>
        /// <param name="packageVersion"></param>
        /// <returns></returns>
        private async UniTask UpdatePackageManifest(string packageVersion)
        {
            var package = YooAssets.GetPackage("DefaultPackage");
            var operation = package.UpdatePackageManifestAsync(packageVersion);
            await operation;

            if (operation.Status == EOperationStatus.Succeed)
            {
                //更新成功
            }
            else
            {
                //更新失败
                Debug.LogError(operation.Error);
            }
        }

        /// <summary>
        /// 创建包下载器
        /// </summary>
        /// <returns></returns>
        private ResourceDownloaderOperation CreateDownloader(string packageName)
        {
            Debug.Log("创建补丁下载器.");
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            var package = YooAssets.GetPackage(packageName);
            var downloader = package.CreateResourceDownloader(downloadingMaxNum, failedTryAgain);
            //await downloader;
            return downloader;
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        private async UniTask<bool> Download(ResourceDownloaderOperation op)
        {
            op.BeginDownload();
            await op;
            //检测下载结果
            if (op.Status == EOperationStatus.Succeed)
            {
                return true;
            }

            Debug.LogError($"{op.Error}");
            return false;
        }



        private string GetBuildPipline()
        {
            return EDefaultBuildPipeline.BuiltinBuildPipeline.ToString();
        }

        private string GetPackageName()
        {
            var args = ExtraData.Data as LaunchArgs;
            return args.packageName;
        }

        private EPlayMode GetPlayMode()
        {
            var args = ExtraData.Data as LaunchArgs;
            return args.playMode;
        }

        /// <summary>
        /// 获取资源服务器地址
        /// </summary>
        private string GetHostServerURL()
        {
            var args = ExtraData.Data as LaunchArgs;
            return args.url;


            //        //string hostServerIP = "http://10.0.2.2"; //安卓模拟器地址
            //        string hostServerIP = "http://127.0.0.1";
            //        string appVersion = "v1.0";

            //#if UNITY_EDITOR
            //        if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android)
            //            return $"{hostServerIP}/CDN/Android/{appVersion}";
            //        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS)
            //            return $"{hostServerIP}/CDN/IPhone/{appVersion}";
            //        else if (UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.WebGL)
            //            return $"{hostServerIP}/CDN/WebGL/{appVersion}";
            //        else
            //            return $"{hostServerIP}/CDN/PC/{appVersion}";
            //#else
            //        if (Application.platform == RuntimePlatform.Android)
            //            return $"{hostServerIP}/CDN/Android/{appVersion}";
            //        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            //            return $"{hostServerIP}/CDN/IPhone/{appVersion}";
            //        else if (Application.platform == RuntimePlatform.WebGLPlayer)
            //            return $"{hostServerIP}/CDN/WebGL/{appVersion}";
            //        else
            //            return $"{hostServerIP}/CDN/PC/{appVersion}";
            //#endif
        }

        /// <summary>
        /// 远端资源地址查询服务类
        /// </summary>
        private class RemoteServices : IRemoteServices
        {
            private readonly string _defaultHostServer;
            private readonly string _fallbackHostServer;

            public RemoteServices(string defaultHostServer, string fallbackHostServer)
            {
                _defaultHostServer = defaultHostServer;
                _fallbackHostServer = fallbackHostServer;
            }
            string IRemoteServices.GetRemoteMainURL(string fileName)
            {
                return $"{_defaultHostServer}/{fileName}";
            }
            string IRemoteServices.GetRemoteFallbackURL(string fileName)
            {
                return $"{_fallbackHostServer}/{fileName}";
            }
        }

        /// <summary>
        /// 资源文件流加载解密类
        /// </summary>
        private class FileStreamDecryption : IDecryptionServices
        {
            /// <summary>
            /// 同步方式获取解密的资源包对象
            /// 注意：加载流对象在资源包对象释放的时候会自动释放
            /// </summary>
            AssetBundle IDecryptionServices.LoadAssetBundle(DecryptFileInfo fileInfo, out Stream managedStream)
            {
                BundleStream bundleStream = new BundleStream(fileInfo.FileLoadPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                managedStream = bundleStream;
                return AssetBundle.LoadFromStream(bundleStream, fileInfo.FileLoadCRC, GetManagedReadBufferSize());
            }

            /// <summary>
            /// 异步方式获取解密的资源包对象
            /// 注意：加载流对象在资源包对象释放的时候会自动释放
            /// </summary>
            AssetBundleCreateRequest IDecryptionServices.LoadAssetBundleAsync(DecryptFileInfo fileInfo, out Stream managedStream)
            {
                BundleStream bundleStream = new BundleStream(fileInfo.FileLoadPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                managedStream = bundleStream;
                return AssetBundle.LoadFromStreamAsync(bundleStream, fileInfo.FileLoadCRC, GetManagedReadBufferSize());
            }

            /// <summary>
            /// 获取解密的字节数据
            /// </summary>
            byte[] IDecryptionServices.ReadFileData(DecryptFileInfo fileInfo)
            {
                throw new System.NotImplementedException();
            }

            /// <summary>
            /// 获取解密的文本数据
            /// </summary>
            string IDecryptionServices.ReadFileText(DecryptFileInfo fileInfo)
            {
                throw new System.NotImplementedException();
            }

            private static uint GetManagedReadBufferSize()
            {
                return 1024;
            }
        }

        /// <summary>
        /// 资源文件偏移加载解密类
        /// </summary>
        private class FileOffsetDecryption : IDecryptionServices
        {
            /// <summary>
            /// 同步方式获取解密的资源包对象
            /// 注意：加载流对象在资源包对象释放的时候会自动释放
            /// </summary>
            AssetBundle IDecryptionServices.LoadAssetBundle(DecryptFileInfo fileInfo, out Stream managedStream)
            {
                managedStream = null;
                return AssetBundle.LoadFromFile(fileInfo.FileLoadPath, fileInfo.FileLoadCRC, GetFileOffset());
            }

            /// <summary>
            /// 异步方式获取解密的资源包对象
            /// 注意：加载流对象在资源包对象释放的时候会自动释放
            /// </summary>
            AssetBundleCreateRequest IDecryptionServices.LoadAssetBundleAsync(DecryptFileInfo fileInfo, out Stream managedStream)
            {
                managedStream = null;
                return AssetBundle.LoadFromFileAsync(fileInfo.FileLoadPath, fileInfo.FileLoadCRC, GetFileOffset());
            }

            /// <summary>
            /// 获取解密的字节数据
            /// </summary>
            byte[] IDecryptionServices.ReadFileData(DecryptFileInfo fileInfo)
            {
                throw new System.NotImplementedException();
            }

            /// <summary>
            /// 获取解密的文本数据
            /// </summary>
            string IDecryptionServices.ReadFileText(DecryptFileInfo fileInfo)
            {
                throw new System.NotImplementedException();
            }

            private static ulong GetFileOffset()
            {
                return 32;
            }
        }

        //    /// <summary>
        //    /// 开始热更流程
        //    /// </summary>
        //    public async void Patch()
        //    {
        //        //初始化YooAssets

        //    }

        //    /// <summary>
        //    /// patch完成 , 开始IOC注入
        //    /// </summary>
        //    /// <param name="isSucceed"></param>
        //    private async void PatchManager_onPatchComplete(bool isSucceed)
        //    {

        //#if !UNITY_EDITOR
        //        Debug.Log("dllManager.LoadDLL()");
        //        var dllManager = new DllManager();
        //        await dllManager.LoadDLL();

        //#endif
        //        await LoadEntry(entryName);
        //    }


        //    async UniTask LoadEntry(string entryName)
        //    {
        //        //Debug.Log("LoadEntry" + entryName);
        //        var _Handle = YooAssets.LoadAssetAsync<GameObject>(entryName);
        //        await _Handle.ToUniTask();
        //        var go = _Handle.InstantiateSync();
        //        //Debug.Log("LoadEntry" + go.name);
        //    }
    }



    /// <summary>
    /// 资源文件解密流
    /// </summary>
    public class BundleStream : FileStream
    {
        public const byte KEY = 64;

        public BundleStream(string path, FileMode mode, FileAccess access, FileShare share) : base(path, mode, access, share)
        {
        }
        public BundleStream(string path, FileMode mode) : base(path, mode)
        {
        }

        public override int Read(byte[] array, int offset, int count)
        {
            var index = base.Read(array, offset, count);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] ^= KEY;
            }
            return index;
        }
    }

}