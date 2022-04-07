using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Prism.Commands;
using RevitAPITrainingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILab_5_1_CreateButtonsRibbon
{
    public class MainViewViewModel
    {
        private ExternalCommandData _commandData;

        public DelegateCommand CountPipesCommand { get; }
        public DelegateCommand WallsVolumeCommand { get; }
        public DelegateCommand CountDoorsCommand { get; }

        //public List<Element> pickedObjects { get; } = new List<Element>();
        //public List<PipingSystemType> PipeSystems { get; } = new List<PipingSystemType>();

        //public PipingSystemType SelectedPipeSystem { get; set; }

        public MainViewViewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            CountPipesCommand = new DelegateCommand(OnCountPipesCommand);
            WallsVolumeCommand = new DelegateCommand(OnWallsVolumeCommand);
            CountDoorsCommand = new DelegateCommand(OnCountDoorsCommand);
            //pickedObjects = SelectionUtils.PickObjects(commandData);
            //PipeSystems = PipesUtils.GetPipingSystems(commandData);
        }

        private void OnCountPipesCommand()
        {
            RaiseHideRequest();

            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            TaskDialog.Show("Количество труб", PipesUtils.CountPipes(_commandData).ToString());

            //if (pickedObjects.Count == 0)
            //    return;
            //{

            //    if (PipesUtils.CountPipes(pickedObjects);
            //        {
            //            var oPipe = pickedObject as Pipe;
            //            oPipe.SetSystemType(SelectedPipeSystem.Id);
            //        }

            //    ts.Commit();
            //}

            RaiseShowRequest();
        }

        private void OnWallsVolumeCommand()
        {
            RaiseHideRequest();

            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            TaskDialog.Show("Объем стен", $"Объем выбранных стен {WallsUtils.WallsVolume(_commandData)} м3");

            RaiseShowRequest();
        }

        private void OnCountDoorsCommand()
        {
            RaiseHideRequest();

            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            TaskDialog.Show("Количество дверей", DoorsUtils.CountDoors(_commandData).ToString());

            RaiseShowRequest();
        }

        public event EventHandler HideRequest;
        private void RaiseHideRequest()
        {
            HideRequest?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ShowRequest;
        private void RaiseShowRequest()
        {
            ShowRequest?.Invoke(this, EventArgs.Empty);
        }
    }

}
