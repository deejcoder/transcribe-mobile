using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Transcribe.Controls.ViewModels;

namespace Transcribe.Controls;

public partial class CardView : ContentView
{

    #region Properties


    #region Bindable Properties
    public ObservableCollection<CardViewModel> DataSource
    {
        get => (ObservableCollection<CardViewModel>)base.GetValue(DataSourceProperty);
        set => base.SetValue(DataSourceProperty, value);
    }

    public DataTemplate Template
    {
        get => (DataTemplate)base.GetValue(TemplateProperty);
        set => base.SetValue(TemplateProperty, value);
    }

    public Layout EmptyViewContent
    {
        get => (Layout)base.GetValue(EmptyViewContentProperty);
        set => base.SetValue(EmptyViewContentProperty, value);
    }

    #endregion

    #endregion


    #region Bindable Property Initalizers
    public static BindableProperty DataSourceProperty = BindableProperty.Create(nameof(DataSource), typeof(ObservableCollection<CardViewModel>), typeof(CardView), null, BindingMode.TwoWay, propertyChanged: HandleDataSourcePropertyChanged);
    public static BindableProperty TemplateProperty = BindableProperty.Create(nameof(Template), typeof(DataTemplate), typeof(CardView), null, BindingMode.OneWay, propertyChanged: HandleTemplatePropertyChanged);
    public static BindableProperty EmptyViewContentProperty = BindableProperty.Create(nameof(EmptyViewContent), typeof(Layout), typeof(CardView), null, BindingMode.OneWay, propertyChanged: HandleEmptyViewContentPropertyChanged);
    #endregion


    public CardView()
	{
		InitializeComponent();
	}

    #region Bindable Property Methods

    private static void HandleDataSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        CardView view = (CardView)bindable;
        view.DataSource = (ObservableCollection<CardViewModel>)newValue;
    }
    private static void HandleTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        CardView view = (CardView)bindable;
        view.emptyViewContent.Content = (Layout)newValue;
    }


    private static void HandleEmptyViewContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        CardView view = (CardView)bindable;
        view.emptyViewContent.Content = (Layout)newValue;
    }

    #endregion

    #region Event Listeners

    #endregion
}