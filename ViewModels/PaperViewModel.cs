using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ScrollToDemo.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Platform;

namespace ScrollToDemo.ViewModels
{
    [QueryProperty(nameof(PaperDto), "PaperDto")]
    public partial class PaperViewModel : ObservableObject
    {
        Dictionary<string, Span> _spans = new Dictionary<string, Span>();
        private bool targetRefId = false;

        /// <summary>
        /// 
        /// </summary>
        public ContentPage contentPage;

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<PaperDto> PaperDtos { get; } = new();

        public PaperViewModel() 
        { 
        }

        [ObservableProperty]
        PaperDto paperDto;

        [ObservableProperty]
        bool showReferencePids;

        [ObservableProperty]
        bool isScrollToLabel;

        [ObservableProperty]
        string scrollToLabelName;

        [RelayCommand]
        async Task PaperLoaded(PaperDto dto)
        {
            if (dto == null)
            {
                return;
            }

            ShowReferencePids = Preferences.Default.Get("show_reference_pids", false);

            var paperId = dto.Id;
            var scrollTo = dto.ScrollTo;
            var uid = dto.Uid;
            IsScrollToLabel = dto.ScrollTo;

            ScrollToLabelName = "_" + uid.Substring(4, 3) + "_" + uid.Substring(0, 3);

            if (paperId == 0)
            {
                await SetReferencePids();
            }

            if (IsScrollToLabel)
            {
                await ScrollTo(ScrollToLabelName);
            }
        }

        [RelayCommand]
        async Task SetReferencePids()
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    var vte = contentPage.Content.GetVisualTreeDescendants();
                    using (var enumerator = vte.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            var child = enumerator.Current;
                            if (child != null)
                            {
                                var childType = child.GetType().Name;
                                if (childType == "Label")
                                {
                                    var lbl = child as Label;
                                    var styleId = lbl.StyleId;
                                    var fmt = lbl.FormattedText;
                                    var spn = lbl.FindByName("SP" + styleId) as Span;
                                    if (spn != null)
                                    {
                                        var spanText = spn.Text;
                                        if (ShowReferencePids)
                                        {
                                            spn.Text = spn.StyleId;
                                        }
                                        else
                                        {
                                            spn.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised =>", ex.Message, "Cancel");
                return;
            }
        }

        [RelayCommand]
        async Task ScrollTo(string labelName)
        {
            try
            {
                if (ShowReferencePids == true && targetRefId)
                {
                    labelName = "RID" + labelName;
                }
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    var scrollView = contentPage.FindByName("contentScrollView") as ScrollView;
                    var label = contentPage.FindByName(labelName) as Label;
                    var labelX = label.X; // 468.75 on Windows on Android 0
                    var labelY = label.Y; // 1257.5 on Windows on Android 0
                    

                    if (scrollView != null && label != null)
                    {
#if ANDROID
                        scrollView.ScrollToAsync(labelX, labelY, false);
#elif WINDOWS
                       
                        scrollView.ScrollToAsync(label, ScrollToPosition.Start, true);
                        //scrollView.ScrollToAsync(labelX, labelY, false);
#endif
                    }
                }); 
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exception raised =>", ex.Message, "Cancel");
                return;
            }
        }
    }
}
