﻿using System;
using System.Collections.Generic;
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

namespace CookingBook.Pages
{
    public partial class RecipesPage : Page
    {
        public RecipesPage()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            lvRecipes.ItemsSource = AppData.AppConnect.model01.Recipes.ToList();
        }
    }
}
