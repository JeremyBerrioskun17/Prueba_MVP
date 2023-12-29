using Prueba_PatronMVP.Models;
using Prueba_PatronMVP.Views;
using Prueba_PatronMVP.Presenters;
using Prueba_PatronMVP.Repositories;
using CRUDWinFormsMVP.Views;

namespace Prueba_PatronMVP
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            IPetView petView = new PetView();
            IPetRepository petRepository = new PetRepository();
            new PetPresenter(petView, petRepository);
            Application.Run((Form)petView);
        }
    }
}