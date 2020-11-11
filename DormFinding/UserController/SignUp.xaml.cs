﻿using DormFinding.Models;
using DormFinding.Utils;
using Facebook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        private DispatcherTimer dispatcherTimer;

        public SignUp()
        {
            InitializeComponent();

        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnLoginR_MouseMove(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoginR_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush(Colors.Blue);
        }
        private void btnSignUp_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSignUp.Foreground = new SolidColorBrush(Colors.White);
            btnSignUp.Background = new SolidColorBrush(Colors.Black);
        }

        private void btnSignUp_MouseMove(object sender, MouseEventArgs e)
        {
            btnSignUp.Foreground = new SolidColorBrush(Colors.Black);
            btnSignUp.Background = new SolidColorBrush(Colors.White);
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            icLoading.Visibility = Visibility.Visible;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerOnTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0,400);
            dispatcherTimer.Start();

        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            try
            {
                if (isValidAccount(tbEmailSignUp.Text.Trim(), tbPasswordSignUp.Password.Trim(), tbConfirmPassSignUp.Password.Trim(), cbAgreeTerm))
                {
                    if(Mydatabase.InsertToTableUser(tbEmailSignUp.Text.Trim(), tbPasswordSignUp.Password.Trim(), 0))
                    {
                        Mydatabase.InsertToTableUserProfile(tbEmailSignUp.Text.Trim());
                        Helpers.MakeConfirmMessage(Window.GetWindow(this), "Register Successful~", "Notify");
                    }else
                    {
                        
                    }
                                    
                }
                dispatcherTimer.Stop();
                icLoading.Visibility = Visibility.Collapsed;
            }
            catch (Exception er)
            {

            }
        }
        private bool isValidAccount(string email, string password, string confirmpass, CheckBox cb)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmpass))
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "Please fill out the form", "Error");
                return false;
            }
            else
            {
                if (!password.Equals(confirmpass))

                {
                    Helpers.MakeErrorMessage(Window.GetWindow(this), "Password is not matcher with confirm password", "Error");
                    return false;
                }
                else
                {
                    if (!Helpers.isValidEmail(email))
                    {
                        Helpers.MakeErrorMessage(Window.GetWindow(this), "Email error~", "Error");
                        return false;
                    }
                    else
                    {
                        if (cb.IsChecked == false)
                        {
                            Helpers.MakeErrorMessage(Window.GetWindow(this), "Please agree the term", "Error");
                            return false;
                        }
                    }
                }
                


                return true;
            }
        }

        private void btnLoginR_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


