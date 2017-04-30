﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Microsoft.Templates.UI.Converters
{
    public class MicrosoftTemplatesAuthorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.ToString().ToLower() == "microsoft")
            {
                return parameter == null ? Visibility.Collapsed : Visibility.Visible;
            }
            return parameter == null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}