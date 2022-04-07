using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPILab_5_1_CreateButtonsRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {

        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)// интерфейс IExternalCommand
        //{
        //    var window = new MainView(commandData);
        //    window.ShowDialog();
        //    return Result.Succeeded;
        //}
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitAPILab_5_3";
            application.CreateRibbonTab(tabName);//создание вкладки
            string utilsFolderPath= @"C:\Program Files\RevitAPITraining\"; //путь к приложение (можно взять из свойств проекта в событиях сборки)

            var panel = application.CreateRibbonPanel(tabName, "Количество"); //создаем панель во вкладке

            var button = new PushButtonData("Элементы", "Посчитать", Path.Combine(utilsFolderPath, "RevitAPILab_5_1_CreateButtons.dll"), "RevitAPILab_5_1_CreateButtons.Main");

            Uri uriImage = new Uri(@"C:\Users\v.baranova\Documents\Автоматизация BIM\RevitAPI\RevitAPILabs\RevitAPILab_5_1_CreateButtonsRibbon\RevitAPILab_5_1_CreateButtonsRibbon\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            panel.AddItem(button);



#region добавление_еще_одной_панели

            var panel2 = application.CreateRibbonPanel(tabName, "Задать"); //создаем панель во вкладке

            var button2 = new PushButtonData("Стены", "Тип стен", Path.Combine(utilsFolderPath, "RevitAPILab_5_2_ChangeWallType.dll"), "RevitAPILab_5_2_ChangeWallType.Main");

            Uri uriImage2 = new Uri(@"C:\Users\v.baranova\Documents\Автоматизация BIM\RevitAPI\RevitAPILabs\RevitAPILab_5_1_CreateButtonsRibbon\RevitAPILab_5_1_CreateButtonsRibbon\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            panel2.AddItem(button2);
#endregion


            return Result.Succeeded;
        }
    }
}
