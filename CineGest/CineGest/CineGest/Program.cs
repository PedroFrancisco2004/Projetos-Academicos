using CineGest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        //inserir apenas digitos de 0 a 9 (inteiros)
        public static void Digitos (KeyPressEventArgs e)
        {
            //verifica se o caracter inserido encontra dentro das regras definidas
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

		//inserir apenas digitos de 0 a 9 (floats)
		public static void DigitosFloat(KeyPressEventArgs e)
		{
			//verifica se o caracter inserido encontra dentro das regras definidas
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
				e.Handled = true;
		}
	}
}
