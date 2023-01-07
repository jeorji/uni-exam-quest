using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI.Model;

namespace UI.ViewModel
{
    internal class QuestPage : DefaultViewModel
    {
        public ObservableCollection<UniExamQuest.Quest> FilteredQuests { get; set; }
        private UniExamQuest.Quest selectedQuest;
        public UniExamQuest.Quest SelectedQuest
        {
            get => selectedQuest;
            set
            {
                selectedQuest = value;
                NotifyPropertyChanged();
            }
        }
        private TextBlock questType;
        public TextBlock QuestType
        {
            get => questType;
            set
            {
                questType = value;

                UniExamQuest.Quest.QuestType? choosenType = value.Name switch
                {
                    "REST" => UniExamQuest.Quest.QuestType.REST,
                    "WORK" => UniExamQuest.Quest.QuestType.WORK,
                    "UNIVERSIRTY" => UniExamQuest.Quest.QuestType.UNIVERSIRTY,
                    "ALL" => null
                };

                FilteredQuests = choosenType is null ?
                    new ObservableCollection<UniExamQuest.Quest>(Quests) :
                    new ObservableCollection<UniExamQuest.Quest>(Quests.Where(q => q.Type == choosenType));
                NotifyPropertyChanged("FilteredQuests");
            }
        }
        private List<UniExamQuest.Quest> Quests { get; set; }
        public QuestPage()
        {
            Quests = MODEL.GM.State.Quests;
            FilteredQuests = new ObservableCollection<UniExamQuest.Quest>(Quests);
        }
        private Command? _completeQuest;
        public Command CompleteQuest
        {
            get
            {
                _completeQuest ??= new Command(
                    p => SelectedQuest is not null,
                    p => doQuest());
                return _completeQuest;
            }
        }
        private void doQuest()
        {
            MODEL.GM.State.Player.InteractWith(SelectedQuest);
            MODEL.GM.State.NextDay();
            var info = $"Выполнен квест {SelectedQuest.Name}\n" +
                (SelectedQuest.Health != 0 ? $"Здоровье {SelectedQuest.Health}\n" : "") +
                (SelectedQuest.Mind != 0 ? $"Знания {SelectedQuest.Mind} \n" : "") +
                (SelectedQuest.Happiness != 0 ? $"Счастье {SelectedQuest.Happiness} \n" : "") +
                (SelectedQuest.Satiation != 0 ? $"Еда {SelectedQuest.Satiation} \n" : "") +
                $"\nДень {MODEL.GM.State.Day}";
            MessageBox.Show(info);
        }
    }
}
