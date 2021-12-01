using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace HDF.VSExtend.Test
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// 这是实现此程序集公开的包的类。
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// <br/>
    /// Visual Studio将类视为有效包的最低要求是实现IVsPackage接口并向shell注册自身。
    /// 此包使用托管包框架（MPF）中定义的帮助器类来完成此操作：
    /// 它派生自提供IVsPackage实现的包类接口，并使用框架中定义的注册属性向shell注册自身及其组件。
    /// 这些属性告诉pkgdef创建实用程序要将哪些数据放入.pkgdef文件。
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// <br/>
    /// 要加载到VS中，包必须由&lt；资产类型=“Microsoft.VisualStudio.VsPackage”…&gt；在.vsixmanifest文件中。
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(TestPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class TestPackage : AsyncPackage
    {
        /// <summary>
        /// HDF.VSExtend.TestPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "cc3a78c8-37f1-42eb-9bd6-4bcd20413c12";

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// <br/>
        /// 包的初始化；此方法在包定位后立即调用，因此您可以在此处放置依赖VisualStudio提供的服务的所有初始化代码。
        /// </summary>
        /// <param name="cancellationToken">
        /// A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.
        /// <br/>
        /// 用于监视初始化取消的取消令牌，当VS关闭时可能会发生初始化取消。
        /// </param>
        /// <param name="progress">
        /// A provider for progress updates.
        /// <br/>
        /// 进度更新的提供程序。
        /// </param>
        /// <returns>
        /// A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.
        /// <br/>
        /// 表示包初始化的异步工作的任务，如果没有，则表示已完成的任务。不要从此方法返回null。
        /// </returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            //异步初始化时，当前线程此时可能是后台线程。
            //切换到UI线程后，执行任何需要UI线程的初始化。
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);


            await HDF.VSExtend.Test.HDFTestCommand.InitializeAsync(this);
        }
        #endregion














    }
}
