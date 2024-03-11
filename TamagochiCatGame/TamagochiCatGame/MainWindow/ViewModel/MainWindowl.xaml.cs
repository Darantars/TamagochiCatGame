using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TamagochiCatGame.PetCreateWindow.View;
using static System.Collections.Specialized.BitVector32;




namespace TamagochiCatGame
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Обьект текущего питомца пользователя.
        /// </summary>
        Pet CurrentPet = new Pet();

        /// <summary>
        /// Таймер события уменьшения голода и настроения со временем
        /// </summary>
        public static System.Timers.Timer DecimalTimer;
        
        public MainWindow()
        {
            InitializeComponent();
            PetInishalyze();
            PetViewModalSynq();

        }






        /// <summary>
        /// Создание или загрузка из файла питомца со стартавыми/сохраненными свойствами
        /// </summary>
        public void PetInishalyze()
        {
            //Синхронизация с View
            Health_Bar.Value = CurrentPet.Health;
            Health_Status_TextBlock.Text = CurrentPet.Health.ToString();
            HungerLevel_Bar.Value = CurrentPet.HungerLevel;
            HungerLevel_Status_TextBlock.Text = CurrentPet.HungerLevel.ToString();
            Mood_Bar.Value = CurrentPet.Mood;
            Mood_Status_TextBlock.Text = CurrentPet.Mood.ToString();
            FatigueLevel_Bar.Value = CurrentPet.FatigueLevel;
            FatigueLevel_Status_TextBlock.Text =CurrentPet.FatigueLevel.ToString();

        }

        /// <summary>
        /// Инициализация события уменьшения голода и настроения со временем
        /// </summary>
        public void PetDecimalingTimer()
        {
            DecimalTimer = new System.Timers.Timer(8000);
            DecimalTimer.Elapsed += TimedDecimalEvent;
            DecimalTimer.AutoReset = true;
            DecimalTimer.Enabled = true;
        }

        /// <summary>
        /// Обработка события таймера
        /// </summary>
        public void TimedDecimalEvent(Object source, ElapsedEventArgs e)
        {
            CurrentPet.DecimalEvent();
            Application.Current.Dispatcher.Invoke((Action)(() =>
            {
                PetViewModalSynq();
            }));

        }

        /// <summary>
        /// Метод синхронизации MVVM для класса питомца. В случае необходимости развития проекта лучше заменять на INotifyPropertyChanged.
        /// </summary>
        public void PetViewModalSynq()
        {
            Health_Bar.Value = CurrentPet.Health;
            Health_Status_TextBlock.Text = CurrentPet.Health.ToString();
            HungerLevel_Bar.Value = CurrentPet.HungerLevel;
            HungerLevel_Status_TextBlock.Text = CurrentPet.HungerLevel.ToString();
            Mood_Bar.Value = CurrentPet.Mood;
            Mood_Status_TextBlock.Text = CurrentPet.Mood.ToString();
            FatigueLevel_Bar.Value = CurrentPet.FatigueLevel;
            FatigueLevel_Status_TextBlock.Text = CurrentPet.FatigueLevel.ToString();

            if (CurrentPet.Name == null || CurrentPet.Name == string.Empty)
            {
                Pet_Name_Button.Content = "Создать питомца";
                Pet_Age_Textbox.Text = "У вас пока не было питомца.";
            }
            else
            {
                Pet_Name_Button.Content = CurrentPet.Name;
                Pet_Age_Textbox.Text = "Ваш питомец прожил:    " + CurrentPet.Age.ToString() + "  ч.";
            }
        }

        public void Pet_Name_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet.Name == null || CurrentPet.Name == string.Empty)
            {
                PetCreateWindow.View.PetCreateWindow PetCreateWindow = new PetCreateWindow.View.PetCreateWindow();
                

                if (PetCreateWindow.ShowDialog() == true)
                {
                    CurrentPet.Create(PetCreateWindow.name);
                    PetDecimalingTimer();
                }
            }
            else
            {
                MessageBox.Show("Похоже у вас уже есть питомец.");
            }
            PetViewModalSynq();
        }

        public void Feed_Pet_Button_Click(object sender, EventArgs e)
        {
            if(CurrentPet != null)
            {
                CurrentPet.Feed();
            }
            PetViewModalSynq();
        }

        public void Play_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Play();
            }
            PetViewModalSynq();
        }
        public void Lul_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Lul();
            }
            PetViewModalSynq();
        }
        public void Treat_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Treat();
            }
            PetViewModalSynq();
        }





    }
}
