﻿namespace Dynamic.Translator
{
    #region using

    using System.Reflection;
    using System.Windows;
    using Core.Config;
    using Core.Dependency;
    using Core.Dependency.Manager;
    using Core.ViewModel.Interfaces;
    using ViewModel;

    #endregion

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IocManager.Instance.AddConventionalRegistrar(new BasicConventionalRegistrar());

            IocManager.Instance.RegisterAssemblyByConvention(Assembly.Load("Dynamic.Translator.Core"));
            IocManager.Instance.RegisterAssemblyByConvention(Assembly.Load("Dynamic.Translator"));

            IocManager.Instance.Register<IGrowlNotifications, GrowlNotifiactions>();

            var configurations = IocManager.Instance.Resolve<IStartupConfiguration>();
            configurations.Initialize();
            base.OnStartup(e);
        }
    }
}