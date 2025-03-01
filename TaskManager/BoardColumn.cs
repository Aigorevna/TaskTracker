﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Input;

namespace TaskManager
{
    internal class BoardColumn
    {
        private StackPanel myStackPanel;
        private ScrollViewer myScrollViewer;
        private List<User> users;
        private List<Column> col;
        private string nameB;
        private Window window;
        private User user;
        private int des;
        private int colm;
        private Desk desk;
        
        public ScrollViewer Draw_Stack(List<User> _users, List<Column> columns, string name_of_board, Window _window, User _user, Desk desk)
        {
            this.desk = desk;
            user = _user;
            window = _window;
            window.PreviewKeyDown += Key_down;
            users = _users;
            col = desk.column;
            nameB = name_of_board;
            for (int i = 0; i < users[desk.parrent_id - 1].desk.Count; i++) 
            {
                if (col == users[desk.parrent_id - 1].desk[i].column) 
                { 
                    des = i; 
                } 
            }
            myScrollViewer = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = VertStack()
            };

            return myScrollViewer;
        }
        private StackPanel VertStack()
        {
            var nameBoard = new TextBlock
            {
                Margin = new Thickness(4, 5, 30, 0),
                Text = "Столбцы из " + nameB,
                FontSize = 20
            };

            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };

            panel.Children.Add(nameBoard);
            panel.Children.Add(Back_to_the_boards());
            panel.Children.Add(All_Coloum());
            return panel;
        }

        private StackPanel All_Coloum()
        {
            myStackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            myStackPanel = Stack();

            return myStackPanel;
        }

        private Button Back_to_the_boards()
        {
            var b = new Button()
            {
                Content = "Назад к доскам",
                Margin = new Thickness(10, 30, 15, 0),
                Width = 140,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            b.Click += Back_Click;
            return b;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var board = new Board();
           
            var a = new UserPageWindow(user);
            a.Show();
            window.Close();
        }

        private StackPanel Stack()
        {
            
            foreach (var c in col)
            {
                myStackPanel.Children.Add(Column(c.cards));
                
            }

            myStackPanel.Children.Add(Jopumn());
            
            return myStackPanel;
        }

        private void Task_Click(StackPanel cards, int index, Cards card, User user)
        {
            TaskWindow taskWindow = new TaskWindow(cards, index, card, user, desk);
            taskWindow.Show();
            //Сохранение изменений карточки карточки

        }

        private Border Column(List<Cards> cards_all)
        {
            int num_col = 0;
            for (int i = 0; i < col.Count; i++)
            {
                if (col[i].cards == cards_all)
                {
                    num_col = i;
                }
            }

            Border bord = new Border
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Padding = new Thickness(3),
                CornerRadius = new CornerRadius(5),
                Effect = new DropShadowEffect { BlurRadius = 30, Color = Colors.Black, ShadowDepth = 0 }
            };

            StackPanel myStack = new StackPanel();
            if (cards_all != null)
            {
                foreach (var card in cards_all)
                {
                    if ( !myStack.Children.Contains(card.btn))
                    {
                        card.btn.Click += (s, e) => Task_Click(myStack, num_col, card, user);
                        myStack.Children.Add(card.btn);
                    }
                }
            }

            var plus = new Button
            {
                Margin = new Thickness(20),
                Width = 225,
                Height = 40,
                Content = "+ Карточка"
            };
            plus.Click += (s, e) => PlusCard(myStack, num_col);

            myStack.Children.Add(plus);
            bord.Child = myStack;

            return bord;
        }
        private void PlusCard(StackPanel stack, int num_col)
        {
            for (int i=0; i < col.Count; i++)
            {
                if (col[i].cards.Count > 0 && stack != null)
                {
                    if (stack.Children.Contains(col[i].cards[0].btn)) { colm = i; }
                }
            }
            int[] path = new int[4] { desk.parrent_id - 1, des, num_col, 0};
            MessageBox.Show(des.ToString());
            if (col[colm].cards.Count > 0) 
            {
                path[3] = col[colm].cards.Count; 
            }

            var newCard = new Cards("Новая карточка", null, "#0000FF", path);

            users[desk.parrent_id - 1].desk[des].column[num_col].cards.Add(newCard);
            Read.Write(users);
           
            newCard.btn.Click += (s, e) => Task_Click(stack, stack.Children.Count - 1, newCard, user);
            stack.Children.Insert(stack.Children.Count - 1, newCard.btn);

            TaskWindow taskWindow = new TaskWindow(stack, stack.Children.Count - 2, newCard, user, desk);
            taskWindow.Show();
            
        }

        private Border Jopumn()
        {
            Border Man = new Border
            {
                Margin = new Thickness(10),
                Background = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Padding = new Thickness(3),
                CornerRadius = new CornerRadius(5),
                Effect = new DropShadowEffect { BlurRadius = 30, Color = Colors.Black, ShadowDepth = 0 }
            };
            StackPanel Bruh = new StackPanel();

            Button AddJopumn = new Button
            {
                Background = new SolidColorBrush(Colors.Blue),
                Margin = new Thickness(10),
                Width = 50,
                Height = 40,
                Content = "+"
            };
            AddJopumn.Click += new RoutedEventHandler(AddJopumn_Click);

            Bruh.Children.Add(AddJopumn);
            Man.Child = Bruh;
            return Man;

        }
        private void AddJopumn_Click(object sender, RoutedEventArgs e)
        {
            if (myStackPanel.Children.Count - 1 < 10)
            {
                myStackPanel.Children.Insert(myStackPanel.Children.Count - 1, Column(null));
                if(myStackPanel.Children.Count - 1 == 10)
                    myStackPanel.Children.RemoveAt(myStackPanel.Children.Count - 1);
            }
        }

        private void Key_down(object sender, KeyEventArgs e)
        {
            var m = new Moving_cards();
            if (e.Key == Key.P)
            {
                m.Move(myScrollViewer, window, desk);
            }
        }
    }
}
