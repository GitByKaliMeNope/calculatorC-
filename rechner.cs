using System;
using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        // Erstelle ein Fenster
        var window = new Window("Taschenrechner");
        window.SetDefaultSize(250, 200);
        window.DeleteEvent += (sender, e) => Application.Quit();

        // Erstelle ein vertikales Layout für das Display und die Buttons
        var vbox = new VBox();
        var entry = new Entry();
        vbox.PackStart(entry, true, true, 10);

        // Definiere die Buttons
        var button1 = new Button("1");
        var button2 = new Button("2");
        var button3 = new Button("3");
        var button4 = new Button("4");
        var button5 = new Button("5");
        var button6 = new Button("6");
        var button7 = new Button("7");
        var button8 = new Button("8");
        var button9 = new Button("9");
        var button0 = new Button("0");

        var buttonPlus = new Button("+");
        var buttonMinus = new Button("-");
        var buttonMultiply = new Button("*");
        var buttonDivide = new Button("/");

        var buttonEqual = new Button("=");
        var buttonClear = new Button("C");

        // Setze die Buttons-Logik
        button1.Clicked += (sender, e) => entry.Text += "1";
        button2.Clicked += (sender, e) => entry.Text += "2";
        button3.Clicked += (sender, e) => entry.Text += "3";
        button4.Clicked += (sender, e) => entry.Text += "4";
        button5.Clicked += (sender, e) => entry.Text += "5";
        button6.Clicked += (sender, e) => entry.Text += "6";
        button7.Clicked += (sender, e) => entry.Text += "7";
        button8.Clicked += (sender, e) => entry.Text += "8";
        button9.Clicked += (sender, e) => entry.Text += "9";
        button0.Clicked += (sender, e) => entry.Text += "0";

        // Speichern der Eingabeoperation
        double result = 0;
        string currentOperation = "";

        buttonPlus.Clicked += (sender, e) => {
            result = double.Parse(entry.Text);
            currentOperation = "+";
            entry.Text = "";
        };

        buttonMinus.Clicked += (sender, e) => {
            result = double.Parse(entry.Text);
            currentOperation = "-";
            entry.Text = "";
        };

        buttonMultiply.Clicked += (sender, e) => {
            result = double.Parse(entry.Text);
            currentOperation = "*";
            entry.Text = "";
        };

        buttonDivide.Clicked += (sender, e) => {
            result = double.Parse(entry.Text);
            currentOperation = "/";
            entry.Text = "";
        };

        // Berechnung des Ergebnisses
        buttonEqual.Clicked += (sender, e) => {
            double secondOperand = double.Parse(entry.Text);
            switch (currentOperation)
            {
                case "+":
                    result += secondOperand;
                    break;
                case "-":
                    result -= secondOperand;
                    break;
                case "*":
                    result *= secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                    {
                        result /= secondOperand;
                    }
                    else
                    {
                        entry.Text = "Fehler";
                        return;
                    }
                    break;
            }
            entry.Text = result.ToString();
        };

        // Löschen der Eingabe
        buttonClear.Clicked += (sender, e) => entry.Text = "";

        // Layout der Buttons
        var grid = new Grid();
        grid.Attach(button1, 0, 0, 1, 1);
        grid.Attach(button2, 1, 0, 1, 1);
        grid.Attach(button3, 2, 0, 1, 1);
        grid.Attach(button4, 0, 1, 1, 1);
        grid.Attach(button5, 1, 1, 1, 1);
        grid.Attach(button6, 2, 1, 1, 1);
        grid.Attach(button7, 0, 2, 1, 1);
        grid.Attach(button8, 1, 2, 1, 1);
        grid.Attach(button9, 2, 2, 1, 1);
        grid.Attach(button0, 1, 3, 1, 1);
        grid.Attach(buttonPlus, 3, 0, 1, 1);
        grid.Attach(buttonMinus, 3, 1, 1, 1);
        grid.Attach(buttonMultiply, 3, 2, 1, 1);
        grid.Attach(buttonDivide, 3, 3, 1, 1);
        grid.Attach(buttonEqual, 2, 3, 1, 1);
        grid.Attach(buttonClear, 0, 3, 1, 1);

        // Füge das Grid zum Fenster hinzu
        vbox.PackStart(grid, true, true, 10);
        window.Add(vbox);

        // Zeige das Fenster an
        window.ShowAll();
        Application.Run();
    }
}
