﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace TaskManager
{
    internal class Task
    {
        public ScrollViewer Draw_Stack(Window window)
        {
            var a = new Task();
            StackPanel myStackPanel = new StackPanel();
            var myScrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = Stack(myStackPanel)
            };

            return myScrollViewer;
        }
        private Border Stack(StackPanel stack)
        {
            Border bord = new Border
            {
                Width = 600,
                Margin = new Thickness(20),
                Background = new SolidColorBrush(Colors.White),
                Padding = new Thickness(3),
                HorizontalAlignment = HorizontalAlignment.Center,
                CornerRadius = new CornerRadius(5),
                Effect = new DropShadowEffect { BlurRadius = 30, Color = Colors.Black, ShadowDepth = 0 }
            };

            var RenameText = new TextBlock
            {
                Margin = new Thickness(30, 30, 30, 0),
                Text = "Переименовать:",
                FontSize = 20
            };
            var Rename = new TextBox
            {
                Background = new SolidColorBrush(Colors.ForestGreen),
                Foreground = new SolidColorBrush(Colors.Azure)
            };

            var ChangeColorText = new TextBlock
            {
                Margin = new Thickness(30, 30, 30, 0),
                Text = "Поменять цвет:",
                FontSize = 20
            };
        
            stack.Children.Add(RenameText);
            stack.Children.Add(Rename);
            stack.Children.Add(ChangeColorText);
            stack.Children.Add(Horizontal());
            bord.Child = stack;
            return bord;
        }

        private WrapPanel Horizontal()
        {
            WrapPanel myPanel = new WrapPanel
            {
                Orientation = Orientation.Horizontal
            };
            var Gray = new Button
            {
                Background = new SolidColorBrush(Colors.Gray),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Серый"
            };
            var Purple = new Button
            {
                Background = new SolidColorBrush(Colors.Purple),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Фиолетовый"
            };

            var Blue = new Button
            {
                Background = new SolidColorBrush(Colors.DeepSkyBlue),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Голубой"
            };

            var Red = new Button
            {
                Background = new SolidColorBrush(Colors.PaleVioletRed),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Розовый"
            };

            var Green = new Button
            {
                Background = new SolidColorBrush(Colors.SeaGreen),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Зелёный"
            };

            var Aqumarine = new Button
            {
                Background = new SolidColorBrush(Colors.Aquamarine),
                Margin = new Thickness(30),
                Width = 130,
                Height = 50,
                Content = "Аквамарин"
            };

            myPanel.Children.Add(Gray);
            myPanel.Children.Add(Purple);
            myPanel.Children.Add(Blue);
            myPanel.Children.Add(Red);
            myPanel.Children.Add(Green);
            myPanel.Children.Add(Aqumarine);

            return myPanel;

        }
    }
}
