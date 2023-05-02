﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DeliveryTest
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"/Photos/{value ?? "non.jpg"}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
