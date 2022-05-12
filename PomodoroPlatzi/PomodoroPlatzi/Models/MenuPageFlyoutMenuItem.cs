﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroPlatzi.Models
{
    public class MenuPageFlyoutMenuItem
    {
        public MenuPageFlyoutMenuItem()
        {
            TargetType = typeof(MenuPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}