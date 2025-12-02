using System.Collections.ObjectModel;
using System.Windows.Input;
using PlantCareMobile.Models;
using PlantCareMobile.Services;

namespace PlantCareMobile.ViewModels
{
    public class RemindersViewModel : BindableObject
    {
        private readonly PlantDatabaseService _databaseService;
        private ObservableCollection<SavedPlant> _plantsDue;

        public ObservableCollection<SavedPlant> PlantsDue
        {
            get => _plantsDue;
            set { _plantsDue = value; OnPropertyChanged(); }
        }

        public ICommand WaterCommand { get; }
        public ICommand RefreshCommand { get; }

        public RemindersViewModel(PlantDatabaseService databaseService)
        {
            _databaseService = databaseService;
            PlantsDue = new ObservableCollection<SavedPlant>();

            // Comando para marcar como regada
            WaterCommand = new Command<SavedPlant>(async (plant) => await WaterPlantAsync(plant));
            
            // Comando para recargar la lista
            RefreshCommand = new Command(async () => await LoadRemindersAsync());

            // Cargar datos al iniciar
            Task.Run(async () => await LoadRemindersAsync());
            
            // Suscribirse a cambios (si agregas una planta nueva, que aparezca aquí)
            PlantMessenger.Subscribe("PlantSaved", async (args) => await LoadRemindersAsync());
        }

        public async Task LoadRemindersAsync()
        {
            try
            {
                var plants = await _databaseService.GetPlantsAsync();
                
                // ORDENAR: Primero las urgentes (fecha de riego ya pasó o es hoy)
                var sortedPlants = plants.OrderBy(p => p.NextWateringDate).ToList();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    PlantsDue = new ObservableCollection<SavedPlant>(sortedPlants);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando recordatorios: {ex.Message}");
            }
        }

        private async Task WaterPlantAsync(SavedPlant plant)
        {
            if (plant == null) return;

            // Efecto visual: Vibración pequeña para confirmar
            try { HapticFeedback.Perform(HapticFeedbackType.Click); } catch { }

            // 1. Actualizar fecha de último riego a HOY
            plant.LastWateredDate = DateTime.Now;
            
            // 2. Guardar en Base de Datos
            await _databaseService.SavePlantAsync(plant);
            
            // 3. Recargar la lista (la planta se moverá al final de la lista)
            await LoadRemindersAsync();
        }
    }
}