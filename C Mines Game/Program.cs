/* FILENAME: Program.cs
 * AUTHOR: William Mack
 * Date Created: 28th January 2019
 * Data Last Modified: 8th February
 * Purpose: Create a grid based computer game with a loop.
 * Brief Description: Computer Systems Assignment
 * License: GPL v2
 *
 * Copyright (C) 2019  William Mack, University of Dundee
 * Microsoft Visual Studio, .NET and other Trademarks and Copyrights 
 * are the property of their respective owners and no infringement is intended.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Mines_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CMinesMain());
        }
    }
}
