﻿Imports Param_RootNamespace.Services

Namespace ViewModels
    ' TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    Public Class SettingsPageViewModel
        Inherits System.ComponentModel.INotifyPropertyChanged

        Private _elementTheme As ElementTheme = ThemeSelectorService.Theme

        Public Property ElementTheme As ElementTheme
            Get
                Return _elementTheme
            End Get

            Set
                [Param_Setter](_elementTheme, value)
            End Set
        End Property

        Private _versionDescription As String

        Public Property VersionDescription As String
            Get
                Return _versionDescription
            End Get

            Set
                [Param_Setter](_versionDescription, newValue := value)
            End Set
        End Property

        Private _switchThemeCommand As ICommand

        Public ReadOnly Property SwitchThemeCommand As ICommand
            Get
                If _switchThemeCommand Is Nothing Then
                    _switchThemeCommand = New RelayCommand(Of ElementTheme)(Async Sub(param) 
                        Await ThemeSelectorService.SetThemeAsync(param)
                    End Sub)
                End If

                Return _switchThemeCommand
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub Initialize()
            VersionDescription = GetVersionDescription()
        End Sub

        Private Function GetVersionDescription() As String
            Dim package = Windows.ApplicationModel.Package.Current
            Dim packageId = package.Id
            Dim version = packageId.Version

            Return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}"
        End Function
    End Class
End Namespace