﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="The Silly Company">
//   The Silly Company 2016. All rights reserved.
// </copyright>
// <summary>
//   The app.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Sharpnado.Presentation.Forms.RenderedViews;

using SillyCompany.Mobile.Practices.Presentation.Navigables;
using SillyCompany.Mobile.Practices.Presentation.ViewModels;
using SillyCompany.Mobile.Practices.Presentation.ViewModels.TabsLayout;
using Xamarin.Forms;

namespace SillyCompany.Mobile.Practices
{
    /// <summary>
    /// The app.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MaterialFrame.ChangeGlobalTheme(MaterialFrame.Theme.Dark);

            var viewLocator = DependencyContainer.Instance.GetInstance<IViewLocator>();

#if INFINITE_LIST
            var firstScreenView = viewLocator.GetViewFor<SillyBottomTabsPageViewModel>();
#else
            var firstScreenView = viewLocator.GetViewFor<SillyPeopleVm>();
#endif

            MainPage = new NavigationPage((Page)firstScreenView);
            NavigationPage.SetHasNavigationBar(MainPage, false);
            var firstScreenVm = (ANavigableViewModel)firstScreenView.BindingContext;
            firstScreenVm.Load(null);
        }

        /// <summary>
        /// The on parent set.
        /// </summary>
        protected override void OnParentSet()
        {
        }

        /// <summary>
        /// The on start.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            // Initiate Navigation and navigate to the splashscreen
        }

        /// <summary>
        /// The on sleep.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// The on resume.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}