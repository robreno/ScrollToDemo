using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ScrollToDemo.Models;
using ScrollToDemo.Views;

namespace ScrollToDemo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel() 
        { 
        }

        [ObservableProperty]
        PaperDto paperDto;

        [ObservableProperty]
        bool showReferencePids;

        [RelayCommand]
        async Task MainPageAppearing()
        {
           try
            {
                ShowReferencePids = Preferences.Get("show_reference_pids", false);
                await CreatePaperDto();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised in MainViewModel.NavigateTo => ",
                    ex.Message, "Cancel");
            }
        }

        [RelayCommand]
        async Task CreatePaperDto()
        {
            try
            {
                var dto = new PaperDto()
                {
                    Id = 0,
                    ScrollTo = true,
                    Uid = "008.000.001.000",
                    Title = "Foreword",
                    Author = "Divine Conselor",
                    PartId = 0,
                    PartTitle = "Foreword Material",
                    TimeSpan = "0:0:0.0_0:0:2.0"
                };
                this.PaperDto = dto;
                Preferences.Default.Set("show_reference_pids", true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised in MainViewModel.NavigateTo => ",
                    ex.Message, "Cancel");
            }
        }

        [RelayCommand]
        async Task ShowPidsCheckedChanged(bool value)
        {
            try
            {
                Preferences.Default.Set("show_reference_pids", value);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised in MainViewModel.NavigateTo => ",
                    ex.Message, "Cancel");
            }
        }

        [RelayCommand]
        async Task NavigateTo(PaperDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return;
                }

                int paperId = dto.Id;
                string targetPage = "Paper" + paperId.ToString("000");
                await Shell.Current.GoToAsync(targetPage, new Dictionary<string, object>()
                {
                    {"PaperDto", dto }
                });
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised in MainViewModel.NavigateTo => ",
                    ex.Message, "Cancel");
            }
        }
    }
}
